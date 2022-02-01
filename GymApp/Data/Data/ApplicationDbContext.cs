using System;
using System.Collections.Generic;
using System.Text;
using Data.EntityModel;
using GymApp.EntityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<InfoMessage> infoMessages { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }

    }

        
}
