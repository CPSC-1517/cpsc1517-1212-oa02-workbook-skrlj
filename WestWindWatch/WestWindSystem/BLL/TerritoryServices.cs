using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;   // for WestwindContext
using WestWindSystem.Entities;  // for Territory
namespace WestWindSystem.BLL
{
    public class TerritoryServices
    {
        // Define a readonly data field for the DbContext
        private readonly WestWindContext _context;
        // Define a greedy constructor for initailizing the DbContext
        internal TerritoryServices(WestWindContext context)
        {
            _context = context;
        }
        public List<Territory> GetByRegion(int regionID)
        {
            IEnumerable<Territory> queryResult = _context
                .Territories
                .Where(currentItem => currentItem.RegionID == regionID)
                .OrderBy(currentItem => currentItem.TerritoryDescription);
            return queryResult.ToList();
        }
    }
}