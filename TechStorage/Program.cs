using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services;
using TechStorageAPI.ApiKey;

namespace TechStorage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var secret = builder.Configuration.GetSection("ApiKey");
            // Add services to the container.

            builder.Services.AddDbContext<DBContext>(x =>
            {
                x.UseSqlServer(connectionString!);
            }
            ); ;
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IStorageService, StorageService>();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication("ApiKeyAuthenticationScheme")
            .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKeyAuthenticationScheme", options => options.ApiKey = secret.Value);
            builder.Services.AddAuthorization();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
                o.OperationFilter<AuthHeader>()
            ); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}