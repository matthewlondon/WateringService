using Microsoft.EntityFrameworkCore;
using WateringService.Models;

namespace WateringService
{
    public class WateringServiceContext : DbContext
    {
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<RainGauge> RainGauges { get; set; }
        public string DbPath { get; }

        public  WateringServiceContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "wateringservice.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define any additional configurations or relationships here
            // For example, the relationship between Park and RainGauge
            modelBuilder.Entity<RainGauge>()
                .HasOne(r => r.Park)
                .WithMany(p => p.RainGauges)
                .HasForeignKey(r => r.ParkId);

            // The relationship between Park and Tree
            modelBuilder.Entity<Tree>()
                .HasOne(t => t.Park)
                .WithMany(p => p.Trees)
                .HasForeignKey(t => t.ParkId);
        }
    }
}
