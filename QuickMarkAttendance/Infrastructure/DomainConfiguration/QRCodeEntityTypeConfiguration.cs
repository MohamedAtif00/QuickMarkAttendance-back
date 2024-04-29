using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.QrCodeDomain;

namespace QuickMarkAttendance.Infrastructure.DomainConfiguration
{
    public class QRCodeEntityTypeConfiguration : IEntityTypeConfiguration<QrCode>
    {
        public void Configure(EntityTypeBuilder<QrCode> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => QrCodeId.Create(x));
            builder.Property(x => x.CourseId).HasConversion(x =>x.value,x =>CourseId.Create(x));
            builder.Property(q => q.Code).IsRequired();
            builder.Property(q => q.ValidUntil).IsRequired();
            builder.Property(q => q.IsActive).IsRequired();
            builder.HasOne(q => q.Course)
                   .WithMany(c => c.QrCodes)
                   .HasForeignKey(q => q.CourseId);
        }
    }
}
    