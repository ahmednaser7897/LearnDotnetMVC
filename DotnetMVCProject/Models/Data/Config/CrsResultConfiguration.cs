using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetMVCProject.Models.Data.Config;

public class CrsResultConfiguration : IEntityTypeConfiguration<CrsResult>
{
    public void Configure(EntityTypeBuilder<CrsResult> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn(0, 1);

        builder.Property(x => x.Degree)
            .IsRequired();

        builder.HasOne(x => x.Course)
            .WithMany(x => x.CrsResults)
            .HasForeignKey(x => x.CourseId);

        builder.HasOne(x => x.Trainee)
            .WithMany(x => x.CrsResults)
            .HasForeignKey(x => x.TraineeId);

        builder.ToTable("CrsResults");
    }
}