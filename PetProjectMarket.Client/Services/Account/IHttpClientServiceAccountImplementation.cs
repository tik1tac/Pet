using PetProjectMarket.Shared.ModelDTO.Account;

namespace PetProjectMarket.Client.Services.Account
{
    public interface IHttpClientServiceAccountImplementation
    {
        Task Register(UserRegistration userRegistration);
        Task Login(UserLogin userLogin);
        //Task ResetPassword();
        //Task ConfirmEmail();
        //Task ForgotPassword();
        Task Logout();
    }
}
