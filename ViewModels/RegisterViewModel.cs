using System.ComponentModel.DataAnnotations;

namespace LBS.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "To pole jest wymagane")]
		[Display(Name = "Login")]
		public string Username { get; set; }
        [Required(ErrorMessage ="To pole jest wymagane")]
		[Display(Name = "Imie")]
        public string FirstName { get; set; }
		[Required(ErrorMessage = "To pole jest wymagane")]
		[Display(Name = "Nazwisko")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "To pole jest wymagane")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
		[Required(ErrorMessage = "To pole jest wymagane")]
		[DataType(DataType.Password)]
		[Display(Name = "Hasło")]
		public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        [Display(Name ="Potwierdź hasło")]
		[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
