using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using SantaApi.Model;

namespace SantaApi.Persistence
{
	public class SantaDb : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Child> Children { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<ChildGiftOwnership> ChildGiftOwnership { get; set; }
        public SantaDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SantaDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define many to many relation
            modelBuilder.Entity<ChildGiftOwnership>().HasKey(cgo => new { cgo.ChildId, cgo.GiftId });
            modelBuilder.Entity<ChildGiftOwnership>().HasOne(cgo => cgo.Child).WithMany(c => c.ChildGiftOwnership).HasForeignKey(cgo => cgo.ChildId);
            modelBuilder.Entity<ChildGiftOwnership>().HasOne(cgo => cgo.Gift).WithMany(g => g.ChildGiftOwnership).HasForeignKey(cgo => cgo.GiftId);

            //Define unique combination
            modelBuilder.Entity<Child>().HasIndex(c => new { c.Name, c.Age}).IsUnique();
        }
    }
}

