using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
  

    public class User : IdentityUser
    {

        public virtual UserProfile UserProfile { get; set; }
    }
}
