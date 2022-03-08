using Microsoft.Extensions.DependencyInjection; // for IServiceCollection
using Microsoft.EntityFrameworkCore; // for DbContextOptionsBuilder

namespace WestWindSystem
{
    public static class BackEndExtensions
    {
        public static void WestWindBackEndDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {

        }
    }
}
