using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("doctors");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Fullname).HasColumnName("fullname").IsRequired();
        builder.Property(x => x.Specialty).HasColumnName("specialty").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("isactive");
        builder.Property(x => x.HireDat).HasColumnName("hiredat");
        builder.Property(x => x.RoomId).HasColumnName("roomid");

        builder.HasOne(x => x.Room)
            .WithMany(x => x.Doctors)
            .HasForeignKey(x => x.RoomId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}