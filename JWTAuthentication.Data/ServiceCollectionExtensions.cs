using JWTAuthentication.Persistance.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Persistance
{
    public static class ServiceCollectionExtensions
    {
        private const string DBConnectionString = "DBConnectionString";

        public static void AddDBContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            // All DB Connection Strings
            var DBString = configuration.GetConnectionString(DBConnectionString);

            // Context Register
            services.AddDbContext<DBContext>(opt =>
                opt.UseSqlServer(DBString));

        }
    }
}
