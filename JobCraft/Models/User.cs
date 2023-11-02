using Microsoft.AspNetCore.Identity;

namespace JobCraft.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
