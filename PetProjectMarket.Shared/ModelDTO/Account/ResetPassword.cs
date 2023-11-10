using System.ComponentModel.DataAnnotations;

namespace PetProjectMarket.Shared.ModelDTO.Account
{
    public class ResetPassword
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password are not compare")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }
    }
}
