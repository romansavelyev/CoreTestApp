using System;
using CoreTestApp.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreTestApp.Persistance
{
    public class CoreTestAppContext : DbContext
    {
        public CoreTestAppContext() 
        {
        }

        public CoreTestAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Broadcast> Broadcasts { get; set; }
        public DbSet<BroadcastType> BroadcastTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO : move to configuration folder/files
            modelBuilder.Entity<Broadcast>()
                .HasKey(c => c.BroadcastId);

            var defaultBroadcastTypeId = new Guid("0151059b-a859-4931-f3f2-08d773208df1");
            modelBuilder.Entity<Broadcast>()
                .HasData(
                    new Broadcast
                    {
                        BroadcastId = Guid.NewGuid(),
                        Title = "NBA Finals",
                        BroadcastTypeId = defaultBroadcastTypeId
                    },
                    new Broadcast
                    {
                        BroadcastId = Guid.NewGuid(),
                        Title = "WCF Finals",
                        BroadcastTypeId = defaultBroadcastTypeId
                    },
                    new Broadcast
                    {
                        BroadcastId = Guid.NewGuid(),
                        Title = "ECF Finals",
                        BroadcastTypeId = defaultBroadcastTypeId
                    }
                );

            modelBuilder.Entity<BroadcastType>()
                .HasKey(c => c.BroadcastTypeId);

            modelBuilder.Entity<BroadcastType>()
                .HasData(
                    new BroadcastType
                    {
                        BroadcastTypeId = defaultBroadcastTypeId,
                        Name = "Basketball"
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
