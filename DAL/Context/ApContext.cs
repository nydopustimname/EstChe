using Common.Entities;
using EstChe.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL.Context
{
    public class ApContext : IdentityDbContext<User>
    {
        public ApContext(string connectionString) : base(connectionString) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }


        //public override void OnModelCreating ()
    }


    
}
