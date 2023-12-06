using Microsoft.AspNetCore.Identity;

namespace EvidentaMasini.Models
{
    public class user:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
