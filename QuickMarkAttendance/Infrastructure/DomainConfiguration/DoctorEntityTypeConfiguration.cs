using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;
using QuickMarkAttendance.Domain.Entity.RefreshTokenDomain;

namespace QuickMarkAttendance.Infrastructure.DomainConfiguration
{
    public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => DoctorId.Create(x));
        }
    }
}
