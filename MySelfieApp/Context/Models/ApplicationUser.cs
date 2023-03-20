using Microsoft.AspNetCore.Identity;

namespace MySelfieApp.Context.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }
    }
}
