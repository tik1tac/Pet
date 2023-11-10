using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PetProjectMarket.Shared.ModelDTO.Account
{
    [Index("UniqueEntity", IsUnique = true)]
    public class UserRegistration
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "This is field must be filled")]
        public string Email { get; set; }

        [Phone]
        [Required(ErrorMessage = "This is field must be filled")]
        public string Telephone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This is field must be filled")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Field Password and Confirmed Password must be same")]
        public string ConfirmedPassword { get; set; }
    }
}