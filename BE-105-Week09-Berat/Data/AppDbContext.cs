using BE_105_Week09_Berat.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_105_Week09_Berat.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EventModel> Events { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<EventModel> events = [
            new EventModel{ Id = 1, Title = "Title1", Description = "Description1", Date = DateTime.UtcNow.AddMonths(7) },
            new EventModel{ Id = 2, Title = "Title2", Description = "Description2", Date = DateTime.UtcNow.AddDays(7) },
            new EventModel{ Id = 3, Title = "Title3", Description = "Description3", Date = DateTime.UtcNow.AddMonths(2) },
            new EventModel{ Id = 4, Title = "Title4", Description = "Description4", Date = DateTime.UtcNow.AddDays (2) },
        ];

            modelBuilder.Entity<EventModel>().HasData(events);
        }
    }
}
