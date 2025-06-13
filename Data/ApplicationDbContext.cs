using Microsoft.EntityFrameworkCore;
using Template;

namespace Template.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets here
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the WeatherForecast entity
            modelBuilder.Entity<WeatherForecast>(entity =>
            {
                entity.HasKey(e => e.Date);
                entity.Property(e => e.Summary).HasMaxLength(100);
                entity.Property(e => e.TemperatureC).IsRequired();
            });
        }
    }
}
