using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LBS.ViewModels
{
	public class AdminSettingsViewModel
	{
		[Required(ErrorMessage ="Pole jest wymagane")]
		[DataType(DataType.Time)]
		[DisplayName("Początek ostatniej lekcji")]
		public  TimeOnly minTime { get; set; }
		[Required(ErrorMessage = "Pole jest wymagane")]
		[DataType(DataType.Time)]
		[DisplayName("Początek pierwszej lekcji")]
		public TimeOnly maxTime {  get; set; }
	}
}
