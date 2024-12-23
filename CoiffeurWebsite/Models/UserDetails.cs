using Microsoft.AspNetCore.Identity;

namespace CoiffeurWebsite.Models
{
    public class UserDetails : IdentityUser
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}