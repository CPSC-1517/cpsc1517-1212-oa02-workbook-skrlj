using WestWindSystem.DAL; // for WestwindContext
using WestWindSystem.Entities; // for Category

namespace WestWindSystem.BLL 
{
    public class RegionServices
    {
        private readonly WestWindContext _context;

        internal RegionServices(WestWindContext context)
        {
            _context = context;
        }

        public List<Region> Region_List()
        {
            return _context
                .Regions
                .OrderBy(currentItem => currentItem.RegionDescripton)
                .ToList();
        }

        public Region? Region_GetById(int regionId)
        {
            return _context
                .Regions
                .Where(currentItem => currentItem.RegionId == regionId)
                .FirstOrDefault();
        }
    }
}