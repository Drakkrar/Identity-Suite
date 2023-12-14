using Microsoft.AspNetCore.Identity;

namespace Identity_Suite.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public Int32? CountryCode { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; } 
        public string? Address { get; set; }
        public string? Region { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Status { get; set; }
    }
}
