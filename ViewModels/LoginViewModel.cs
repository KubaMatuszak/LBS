using System.ComponentModel.DataAnnotations;

namespace LBS.ViewModels
{
	public class LoginViewModel
    {
		[Required(ErrorMessage = "To pole jest wymagane!")]
		[Display(Name = "Login")]
		public string Username { get; set; }
        [Required(ErrorMessage ="To pole jest wymagane!")]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }
        [DataType(DataType.Password)]
		[Required(ErrorMessage = "To pole jest wymagane!")]
		[Display(Name = "Hasło")]
		public string Password { get; set; }
        [Display(Name ="Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
