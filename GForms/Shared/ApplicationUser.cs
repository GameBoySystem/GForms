using Microsoft.AspNetCore.Identity;

namespace GForms.Shared
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Test>? Tests { get; set; }
    }
}
