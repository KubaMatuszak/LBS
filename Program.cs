using LBS.Data;
using LBS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnection")));
builder.Services.AddDbContext<LessonDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LessonsConnection")));
builder.Services.AddIdentity<LBSUser,IdentityRole>(
options =>
{
	options.Password.RequiredUniqueChars = 0;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 8;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireLowercase = false;
	
}
	).AddEntityFrameworkStores<UsersDbContext>().AddDefaultTokenProviders();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Lesson}/{action=MyLessons}/{id?}");

app.Run();
