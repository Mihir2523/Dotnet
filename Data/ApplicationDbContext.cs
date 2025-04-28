using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data{
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<AppUser>(entity =>
    {
        entity.HasKey(e => e.Email);  // Confirm Email is primary key
        
        // Optional: make email case-insensitive in PostgreSQL
        entity.Property(e => e.Email)
            .HasColumnType("citext");
    });
}

}
}