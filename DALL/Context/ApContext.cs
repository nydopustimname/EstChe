using Common.Entities;
using Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.Context
{
    public class ApContext : IdentityDbContext<User>
    {

        public ApContext(string connectionString) : base(connectionString) { }
        public ApContext() : base("ApContext") { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Cart> ShoppingCart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public static ApContext Create()
        {
            return new ApContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserProfile>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
    }
}
