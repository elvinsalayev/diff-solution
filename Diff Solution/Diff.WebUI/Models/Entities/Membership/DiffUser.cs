using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Diff.WebUI.Models.Entities.Membership
{
    public class DiffUser : IdentityUser<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string ImagePath { get; set; }
    }
}
