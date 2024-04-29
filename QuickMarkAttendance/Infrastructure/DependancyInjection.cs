using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuickMarkAttendance.Application.DTOs.JwtSetting;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;
using QuickMarkAttendance.Infrastructure.Repositories;
using System.Text;

namespace QuickMarkAttendance.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(x =>x.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
            {
                // Configure password requirements
                options.Password.RequiredLength = 8; // Minimum password length
                options.Password.RequireDigit = false; // Requires at least one digit
                options.Password.RequireLowercase = false; // Requires at least one lowercase letter
                options.Password.RequireUppercase = false; // Requires at least one uppercase letter
                options.Password.RequireNonAlphanumeric = false; // Requires at least one non-alphanumeric character

            }).AddRoles<IdentityRole<Guid>>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            var jwtSettings = configuration.GetSection("JwtSettings");

            var setting = services.Configure<JwtSettings>(jwtSettings);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.ClaimsIssuer = jwtSettings["Issuer"];
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SigningKey"])),
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audiance"]

                };
                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            context.Response.Headers.Add("IS_TOKEN_EXPIRED", "Y");
                        return Task.CompletedTask;

                    }
                };

            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IQrCodeRepository, QrCodeRepository>();
            services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();



            return services;

        }
    }
}
