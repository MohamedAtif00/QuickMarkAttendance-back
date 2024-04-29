using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickMarkAttendance.Domain.Entity.RefreshTokenDomain;

namespace QuickMarkAttendance.Infrastructure.DomainConfiguration
{
    public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => RefreshTokenId.Create(x));
        }
    }
}
