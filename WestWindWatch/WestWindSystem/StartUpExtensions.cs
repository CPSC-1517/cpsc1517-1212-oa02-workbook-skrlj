using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
using WestWindSystem.BLL;
#endregion

namespace WestWindSystem
{
    //extension methods must belong to a static class
    public static class StartupExtensions
    {
        //you can add any extension must for and class that exists within C#
        public static void AddBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //the first parameter of your method referes to the class you are attempting to 
            //   extend
            //syntac for the firat parameter:  this theclassbeingextend parametername
            //any additinal arguments exsiting on the callin statement follow the 
            //   first parameter separated by commas
            //add the context class of your application library (DAL) to the service
            //  collection
            //pass in the connection string options
            services.AddDbContext<WestWindContext>(options);


            //add any business logic layer class to the service collection so oour
            //  web app has access to the methods within the BLL class
            //the argument for the AddTransient is called a factory
            //basically what you are adding is a localize method
            //services.AddTransient<WestWindServices>((serviceProvider) =>
            //{
            //    //get the dbcontext class
            //    var context = serviceProvider.GetRequiredService<WestWindContext>();
            //    //create an instance of WestWindServices supplying the reference to
            //    //   the context class
            //    return new WestWindServices(context);
            //});
            //services.AddTransient<RegionServices>((serviceProvider) =>
            //{
            //    var context = serviceProvider.GetRequiredService<WestWindContext>();
            //    return new RegionServices(context);
            //});
            //services.AddTransient<TerritoryServices>((serviceProvider) =>
            //{
            //    var context = serviceProvider.GetRequiredService<WestWindContext>();
            //    return new TerritoryServices(context);
            //});
        }
    }
}