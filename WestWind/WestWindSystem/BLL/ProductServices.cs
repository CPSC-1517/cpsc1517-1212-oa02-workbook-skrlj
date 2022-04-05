using WestWindSystem.DAL;   // for WestContext;
using WestWindSystem.Entities;  // for Product

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        // Step 1: Define a readonly public DbContext field that is intialized using
        // constructor injection
        private readonly WestWindContext _dbContext;
        internal ProductServices(WestWindContext context)
        {
            _dbContext = context;
        }

        // Step 2: Define operations to perform with entity
        public List<Product> Product_GetByCategoryID(int categoryID)
        {
            return _dbContext
                .Products
                .Where(p => p.CategoryID == categoryID)
                .ToList();
        }

        public List<Product> Product_GetByPartialProductName(string partialProductName)
        {
            return _dbContext
                .Products
                .Where(p => p.ProductName.Contains(partialProductName))
                .ToList();
        }
        public Product Product_GetByID(int productID)
        {
            return _dbContext
                .Products
                .Where(p => p.ProductID == productID)
                .FirstOrDefault();

        }
        // Step 1: Add a method to your BLL class to return only a subset of data.For example:
        public List<Product> Product_GetByPartialProductName(string partialProductName, int pageSize, int pageNumber, out int count)
        {
            var query = _dbContext
                .Products
                .Where(p => p.ProductName.Contains(partialProductName));
            count = query.Count();
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

    }
}