using WestWindSystem.DAL; // for WestwindContext
using WestWindSystem.Entities; // for BuildVersion

namespace WestWindSystem.BLL
{
    public class BuildVersionServices
    {
        private readonly WestWindContext _context;

        internal BuildVersionServices(WestWindContext context)
        {
            _context = context;
        }

        // THink of context as the database and Dbset as the tables
        public BuildVersion? GetBuildVersion()
        {
            return _context.BuildVersions.FirstOrDefault();
        }
    }
}
