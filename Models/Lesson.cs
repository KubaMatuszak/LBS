using System.ComponentModel.DataAnnotations;

namespace LBS.Models
{
	public class Lesson
	{
        public int Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set;}
        [Required(ErrorMessage ="Pole jest wymagane")]
        [DataType(DataType.Date)]
        public DateOnly LessonDate { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [DataType(DataType.Time)]
        public TimeOnly LessonTime { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        
        public int LessonLength { get; set; }
    }
}
