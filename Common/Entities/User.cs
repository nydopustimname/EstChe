using Microsoft.AspNet.Identity.EntityFramework;


namespace Common.Entities
{
    public class User : IdentityUser
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
