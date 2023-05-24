using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models.Auth
{
    public class MyAppUser:IdentityUser
    {
        public string Name { get; set; }
        public string IsActive { get; set;}
    }
}
