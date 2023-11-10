using Application.Notification;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetProject.Server.Models;
using PetProject.Server.Models.StatusCodesModels;

using PetProjectMarket.Shared.Model;
using PetProjectMarket.Shared.ModelDTO.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepositoryWrapper wrapper;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly UserManager<UserEntity> userManager;
        private readonly SignInManager<UserEntity> signInManager;

        public AccountController(IRepositoryWrapper _wrapper, IMapper _mapper, UserManager<UserEntity> _user,
            SignInManager<UserEntity> _signInManager, IMediator _mediator)
            => (wrapper, mapper, userManager, signInManager, mediator) =
                (_wrapper, _mapper, _user, _signInManager, _mediator);


        [HttpPost("/Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] UserRegistration modeluser)
        {
            if (modeluser is null)
                return BadRequest(new RegisterStateModel { ErrorMessage = "Invalid Registration" });

            var user = mapper.Map<UserEntity>(modeluser);
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);
            }

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var body = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);

            var email = new EmailMetadata(user.Email, "ConfirmEmail", $"Подтвердите почту: + {body}");
            await mediator.Publish(new UserAddedNotification(email));

            await userManager.AddToRoleAsync(user, "Visitor");

            return Created("", user);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
                return BadRequest(new ConfirmEmailModel { ErrorConfirm = "This is User are not find" });

            var result = await userManager.ConfirmEmailAsync(user, token);
            return Ok(result.Succeeded ? new ConfirmEmailModel { SuccessConfirm = true } : new ConfirmEmailModel { ErrorConfirm = "Error" });
        }

        //public IActionResult SuccededRegistration() => View();

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(string returnUrl)
        //{
        //    ViewData["returnUrl"] = returnUrl;
        //    await Task.Delay(0);
        //    return View();
        //}

        [HttpPost("/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            if (user is null)
                return BadRequest(user);

            var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded &&
                await userManager.IsInRoleAsync(await wrapper.User.GetByEmail(user.Email), "Admin"))
                return Ok(new LoginModel { SuccessAuth = true });

            if (result.Succeeded)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey"));
                var signInCreditional = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5116",
                    audience: "http://localhost:5116",
                    signingCredentials: signInCreditional,
                    expires: DateTime.Now.AddMinutes(5)
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new LoginModel { Token = tokenString });
            }

            if (result.IsLockedOut)
            {
                var link = Url.Action(nameof(ForgotPassword), "Account", new { }, Request.Scheme);

                var message = new EmailMetadata(user.Email, "Account is locked",
                    $"Account is Locked,tap on lin:{link}");

                await mediator.Publish(new LockedUserNotification(message));

                ModelState.TryAddModelError("", $"User is locked");
                return NoContent();
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return BadRequest(new LoginModel { ErrorAuth = "Invalid data" });
            }
        }

        [HttpPost("/Logout"), Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return NoContent();
        }

        //[HttpGet]
        //public IActionResult ForgotPassword() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPassword forgot)
        {
            var user = await userManager.FindByEmailAsync(forgot.Email);
            if (user == null)
                return BadRequest(new ForgotAndResetPassModel { ErrorMessage = "User not found" });

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = forgot.Email },
                Request.Scheme);

            var message = new EmailMetadata(user.Email, "Reset Password", callback);
            await mediator.Publish(new ResetPasswordUserNotification(message));

            return Ok();
        }

        //public IActionResult ForgotPasswordConfirmation() => View();

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var reset = new ResetPassword { Token = token, Email = email };

            return Ok(new ForgotAndResetPassModel { SuccesChangePass = true });
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword reset)
        {
            var user = await userManager.FindByEmailAsync(reset.Email);
            if (user is null)
                return Unauthorized(new ForgotAndResetPassModel { ErrorMessage = "This is user not found" });

            if (!(await userManager.CheckPasswordAsync(user, reset.Password)))
                return BadRequest(new ForgotAndResetPassModel { ErrorMessage = "Password trubble" });

            var result = await userManager.ResetPasswordAsync(user, reset.Token, reset.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return Ok();
            }

            return Ok(new ForgotAndResetPassModel { SuccesChangePass = true });
        }

        //[HttpGet]
        //public IActionResult ResedPasswordConfirmation() => View();

        //private async Task<IActionResult> RedirectToLocal(string returnUrl)
        //{
        //    await Task.Delay(0);
        //    if (Url.IsLocalUrl(returnUrl))
        //        return Redirect(returnUrl);

        //    return RedirectToAction(nameof(HomeController.HomePage), "Home");
        //}

        //[HttpGet]
        //public IActionResult Error() => View();
    }
}

