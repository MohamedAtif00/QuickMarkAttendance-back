using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.RefreshTokenDomain;

namespace QuickMarkAttendance.Domain.Repository
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken, RefreshTokenId>
    {
        Task<RefreshToken> FindByToken(string token);
        Task<RefreshToken> GetRefreshTokenByUserId(Guid userId);
    }
}