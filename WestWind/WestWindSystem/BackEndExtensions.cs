using Microsoft.EntityFrameworkCore;    // for DbContextOptionsBuilder
using Microsoft.Extensions.DependencyInjection; // for IServiceCollection, Action
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.BLL;   // for CategoryServices
using WestWindSystem.DAL;   // for WestWindContext

namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void BackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {

            services.AddDbContext<WestWindContext>(options);

            services.AddTransient<CategoryServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<WestWindContext>();
                return new CategoryServices(dbContext);
            });

            services.AddTransient<ProductServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<WestWindContext>();
                return new ProductServices(dbContext);
            });

            services.AddTransient<SupplierServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<WestWindContext>();
                return new SupplierServices(dbContext);
            });
        }

    }
}