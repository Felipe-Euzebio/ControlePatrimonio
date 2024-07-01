using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class User : IdentityUser
    {
        public string SocialSecurityNumber { get; set; }
    }
}