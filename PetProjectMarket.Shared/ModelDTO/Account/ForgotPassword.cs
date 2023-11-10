using System.ComponentModel.DataAnnotations;

namespace PetProjectMarket.Shared.ModelDTO.Account
{
    public class ForgotPassword
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
