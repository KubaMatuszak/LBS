using System.ComponentModel.DataAnnotations;

namespace LBS.ViewModels
{
	public class RegisterViewModel
	{
        [Required(ErrorMessage ="To pole jest wymagane")]
        public string FirstName { get; set; }
		[Required(ErrorMessage = "To pole jest wymagane")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "To pole jest wymagane")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
		[Required(ErrorMessage = "To pole jest wymagane")]
		[DataType(DataType.Password)]   
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        [Display(Name ="Potwierdź hasło")]
        public string ConfirmPassword { get; set; }

    }
}
