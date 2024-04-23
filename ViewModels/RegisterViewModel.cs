using System.ComponentModel.DataAnnotations;

namespace LBS.ViewModels
{
	public class RegisterViewModel
	{
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }

    }
}
