﻿using Microsoft.Extensions.DependencyInjection; // for IServiceCollection
using Microsoft.EntityFrameworkCore; // for DbContextOptionsBuilder
using WestWindSystem.DAL;
using WestWindSystem.BLL;

namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void WestWindBackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //within this method, we will register all the services
            //that will be used by the system (context setup)
            //   and will be provided by the system
            //setup the context service
            services.AddDbContext<WestWindContext>(options);
            //register the service classes
            //add any business logic layer class to the service collection so our
            //  web app has access to the methods (services) within the BLL class
            //the argument for the AddTransient is called a factory
            //basically what your are add is a localize method
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                //get the dbcontext class that has been registered
                var context = serviceProvider.GetService<WestWindContext>();
                //create an instance of the service class (BuildVersionServices) supplying
                //  the context reference to the service class
                //return the service class instance
                return new BuildVersionServices(context);
            });
            services.AddTransient<CategoryServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();
                return new CategoryServices(context);
            });
        }
    }
}