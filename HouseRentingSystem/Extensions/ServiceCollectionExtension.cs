namespace HouseRentingSystem.Extensions
{
    using HouseRentingSystem.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    public static class ServiceCollectionExtension
    {
        public static IServiceCollecztion AddAplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddAplicationDbContext(this IServiceCollection services,IConfiguration config)
        {
            var connectionString = config
                .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();


            return services;
        }

        public static IServiceCollection AddAplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
                           options.SignIn.RequireConfirmedAccount = false)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
