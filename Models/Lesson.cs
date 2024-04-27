namespace LBS.Models
{
	public class Lesson
	{
        public int Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set;}
        public DateOnly LessonDate { get; set; }
        public TimeOnly LessonTime { get; set; }
        public int LessonLength { get; set; }
    }
}
