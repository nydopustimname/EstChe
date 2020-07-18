using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL.Context
{
    public class ApContext : IdentityDbContext<User>
    {
        public ApContext(string connectionString) : base(connectionString) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
    
}
