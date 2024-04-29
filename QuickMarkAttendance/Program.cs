
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickMarkAttendance.Application;
using QuickMarkAttendance.Infrastructure;
using QuickMarkAttendance.Infrastructure.Data;
using QuickMarkAttendance.Infrastructure.SeedData;

namespace QuickMarkAttendance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();

                var userMgr = services.GetRequiredService<UserManager<IdentityUser<Guid>>>();
                var roleMgr = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                SeedData.Initialize(context, userMgr, roleMgr).Wait();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowOrigin");
            app.Run();
        }
    }
}
