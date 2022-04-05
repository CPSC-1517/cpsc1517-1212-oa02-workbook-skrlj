using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL; // for WestWindContext
using WestWindSystem.Entities; // for Entities

namespace WestWindSystem.BLL
{
    public class SupplierServices
    {
        private readonly WestWindContext _dbContext;

        internal SupplierServices(WestWindContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public List<Supplier> Supplier_List()
        {
            var query = _dbContext
                .Suppliers
                .OrderBy(s => s.CompanyName);
            return query.ToList();
        }

        public Supplier? Supplier_GetByID(int supplierID)
        {
            var query = _dbContext
                .Suppliers
                .Where(s => s.SupplierID == supplierID);
            return query.FirstOrDefault();
        }
    }
}
