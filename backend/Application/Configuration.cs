using Application.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Configuration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Test"));
            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}