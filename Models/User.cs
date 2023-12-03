using Microsoft.AspNetCore.Identity;

namespace EvidentaMasini.Models
{
    public class User:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
