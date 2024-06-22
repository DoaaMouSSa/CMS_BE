using Microsoft.AspNetCore.Identity;

namespace cms_be.Models
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
