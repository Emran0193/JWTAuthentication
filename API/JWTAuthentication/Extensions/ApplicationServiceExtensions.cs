using AutoMapper.Configuration;
using JWTAuthentication.Persistance.Repository;
using JWTAuthentication.Persistance.Repository.IRepository;
using JWTAuthentication.Services.Services;
using JWTAuthentication.Services.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace JWTAuthentication.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IService, Service>();

            return services;
        }
    }
}
