using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetMVCProject.Models.Data.Config;

public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
{
    public void Configure(EntityTypeBuilder<Trainee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn(0, 1);

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .HasColumnType("VARCHAR")
            .HasMaxLength(500);

        builder.Property(x => x.Address)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Grade)
            .IsRequired();

        builder.ToTable("Trainees");
    }
}
