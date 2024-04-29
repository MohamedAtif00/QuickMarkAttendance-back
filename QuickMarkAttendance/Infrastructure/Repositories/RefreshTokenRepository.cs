using Microsoft.EntityFrameworkCore;
using QuickMarkAttendance.Domain.Entity.RefreshTokenDomain;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken, RefreshTokenId>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken> GetRefreshTokenByUserId(Guid userId)
        {
            return await _context.refreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<RefreshToken> FindByToken(string token)
        {
            return await _context.refreshTokens.Where(x => x.Token == token).FirstOrDefaultAsync();
        }
    }
}
