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

    }
}