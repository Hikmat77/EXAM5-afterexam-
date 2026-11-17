using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Room> Rooms => Set<Room>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctors");
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Fullname).HasColumnName("fullname");
            entity.Property(x => x.Specialty).HasColumnName("specialty");
            entity.Property(x => x.IsActive).HasColumnName("isactive");
            entity.Property(x => x.HireDat).HasColumnName("hiredat");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("patients");
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Fullname).HasColumnName("fullname");
            entity.Property(x => x.Phone).HasColumnName("phone");
            entity.Property(x => x.BirthDate).HasColumnName("birthdate");
            entity.Property(x => x.IsActive).HasColumnName("isactive");
            entity.Property(x => x.CreateAt)
                .HasColumnName("createat")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("rooms");
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Name).HasColumnName("name");
            entity.Property(x => x.IsActive).HasColumnName("isactive");
        });
    }
}