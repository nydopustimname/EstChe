using Microsoft.AspNet.Identity.EntityFramework;


namespace Common.Entities
{
    public class User : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
