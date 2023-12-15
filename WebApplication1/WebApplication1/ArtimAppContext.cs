namespace WebApplication1;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;


public partial class ArtimAppContext : DbContext
{
    public ArtimAppContext()
    {
    }

    public ArtimAppContext(DbContextOptions<ArtimAppContext> options)
    : base(options)
    {
    }




    public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Car { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }

    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
    }
        

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }

       
    






    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        IConfiguration configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("ArtimAppContext"));
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cities_Countries");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Iso2).IsFixedLength();
            entity.Property(e => e.Iso3).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }*/

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
