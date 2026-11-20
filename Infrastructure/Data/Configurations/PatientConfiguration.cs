using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("patients");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Fullname).HasColumnName("fullname").IsRequired();
        builder.Property(x => x.Phone).HasColumnName("phone").IsRequired();
        builder.Property(x => x.BirthDate).HasColumnName("birthdate");
        builder.Property(x => x.IsActive).HasColumnName("isactive");
        builder.Property(x => x.CreateAt)
            .HasColumnName("createat")
            .HasDefaultValueSql("now()");
    }
}
