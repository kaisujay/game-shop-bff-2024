using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Metrics;
using System.Security.Principal;

namespace game_shop_bff_2024.Models
{
    public class PlayerModel : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? Language { get; set; }
        public bool Disabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
