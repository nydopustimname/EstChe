using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    [Table("AspNetRoles")]
  
    public class AppRole : IdentityRole
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int RoleId { get; set; }
        //public string RoleName { get; set; }
        //public string Description { get; set; }

    }
}
