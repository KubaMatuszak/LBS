using LBS.Models;
using Microsoft.EntityFrameworkCore;

namespace LBS.Data
{
	public class LessonDbContext : DbContext
	{
		public LessonDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Lesson> lessons { get; set; }
	}
}
