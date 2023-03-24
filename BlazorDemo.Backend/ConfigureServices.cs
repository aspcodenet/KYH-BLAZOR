using BlazorDemo.Backend.Data;
using BlazorDemo.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlazorDemo.Backend
{
    public static class ConfigureServices
    {
        /// <summary>
        /// Custom extension method to register all services needed for our backend infrastructure. 
        /// </summary>
        /// <remarks>
        /// <c>The idea behind this approach is to keep our program as cleas as possible and re-use the same code in different applications</c>
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Read about extension methods</see>
        /// <para>
        /// <c>The Dependency injection container for each application will be responsible for creating each required service and 
        /// the same for the DbContext registration. </c>
        /// </para>
        /// </remarks>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection ConfigureBackendServices(this IServiceCollection services, IConfiguration configuration)
        {
            // When working with blazor server it is recommended to use db context factory as the normal dbContext is registered as Scoped but because the life time of a
            // blazor component is managed by the circuit of the SignalR Hub then the life time could be longer than the none thread safe dbContext could handle. 
            //services.AddDbContextFactory<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DataInitializer>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
