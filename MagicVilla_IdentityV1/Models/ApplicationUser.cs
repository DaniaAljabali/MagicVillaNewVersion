using Microsoft.AspNetCore.Identity;

namespace MagicVilla_IdentityV1.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
