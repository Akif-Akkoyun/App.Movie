using Microsoft.AspNetCore.Identity;

namespace App.Movie.Persistence.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
