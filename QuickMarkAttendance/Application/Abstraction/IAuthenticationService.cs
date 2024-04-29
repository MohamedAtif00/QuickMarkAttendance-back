using Ardalis.Result;
using Microsoft.AspNetCore.Identity;
using QuickMarkAttendance.Application.DTOs.JwtSetting;
using System.Security.Claims;

namespace QuickMarkAttendance.Application.Abstraction
{
    public interface IAuthenticationService
    {
        Task<Result<string>> CheckUsername(string username);
        Task<Result> ConfirmEmail(string userId, string code);
        Task<string> GenerateAccessToken(ClaimsIdentity claimsIdentity);
        Task<ClaimsIdentity> GenerateClaimsIdentity(IdentityUser<Guid> user, string role);
        Task<string> GenerateRefreshToken(IdentityUser<Guid> newUser, string Token);
        Task<Result<JwtTokenDto>> Login(string username, string password, string role);
        Task<Result<JwtTokenDto>> Register(string Username, string Email, string Password, string Role,string ip);
    }
}
