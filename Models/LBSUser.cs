using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LBS.Models
{
	public class LBSUser:IdentityUser
	{
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       
    }
}
