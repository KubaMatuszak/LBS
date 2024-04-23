using LBS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LBS.Data
{
	public class UsersDbContext : IdentityDbContext<LBSUser>
	{
		public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
		{
		}
	}
}
