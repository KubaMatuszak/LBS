using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace LBS.ViewModels
{
	public class LessonViewModel
	{
		
		public string StudentFirstName { get; set; }
		public string StudentLastName { get; set; }
		[Required(ErrorMessage ="Pole jest wymagane")]
		[DataType(DataType.Date)]
		
		[Display(Name ="Data zajęć")]
		
		public DateOnly LessonDate { get; set; }
		[Required(ErrorMessage = "Pole jest wymagane")]
		[DataType(DataType.Time)]
		[Display(Name ="Godzina zajęć")]
		public TimeOnly LessonTime { get; set; }
		[Required(ErrorMessage = "Pole jest wymagane")]
		[Display(Name = "Czas trwania zajęć w minutach")]

		public int LessonLength { get; set; }
	}
}
