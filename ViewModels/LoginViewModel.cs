using System.ComponentModel.DataAnnotations;

namespace LBS.ViewModels
{
	public class LoginViewModel
    {
        [Required(ErrorMessage ="To pole jest wymagane!")]   
        
        public string Username { get; set; }
        [DataType(DataType.Password)]
		[Required(ErrorMessage = "To pole jest wymagane!")]
		public string Password { get; set; }
        [Display(Name ="Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
