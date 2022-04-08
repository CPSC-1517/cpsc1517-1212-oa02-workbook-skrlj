using WestWindSystem.DAL; // for WestWindContext
using WestWindSystem.Entities; // for Category
using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.BLL
{
    public class CategoryServices
    {
        // Step 1: Define a readonly data field for the custom DbContext class
        // and use constructor injection to set the value of the data field
        private readonly WestWindContext _dbContext;
        internal CategoryServices(WestWindContext context)
        {
            _dbContext = context;
        }

        public int Category_AddCategory(Category newCategory)
        {
            // Enforce business rule where a CategoryName must be unique
            bool exists = _dbContext.Categories.Any(c => c.CategoryName == newCategory.CategoryName);
            if(exists)
            {
                throw new Exception($"The Category Name {newCategory.CategoryName} already exists");
            }

            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return newCategory.CategoryID;
        }

        public int Category_UpdateCategory(Category existingCategory)
        {
            _dbContext.Categories.Attach(existingCategory).State = EntityState.Modified;
            int rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }


        public int Category_DeleteCategory(int categoryID)
        {
            // enforce business rule where a category may only be deleted if it contains no products
            Category existingCategory = _dbContext.Categories
                .Where(c => c.CategoryID == categoryID)
                .Include(c => c.Products)
                .FirstOrDefault();
            if(existingCategory == null)
            {
                throw new Exception($"CategoryID {categoryID} does not exist");
            }

            int categoryProductCount  = existingCategory.Products.Count();

            if (categoryProductCount > 0)
            {
                throw new Exception("This category has products and cannot be deleted");
            }

            _dbContext.Categories.Remove(existingCategory); 
            int rowsDeleted = _dbContext.SaveChanges();
            return rowsDeleted;
        }

        // Step 2: Define query methods of the Category entity
        public List<Category> Category_List()
        {
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName);
            return query.ToList();
        }

        public Category Category_GetById(int categoryID)
        {
            IEnumerable<Category> singleResultQuery = _dbContext
                .Categories
                .Where(item => item.CategoryID == categoryID);
            return singleResultQuery.FirstOrDefault();
        }

        public List<Category> Category_GetByPartialCategoryNameOrDescription(
            string partialNameOrDescription)
        {
            IEnumerable<Category> resultListQuery = _dbContext
                .Categories
                .Where(item => item.CategoryName.Contains(partialNameOrDescription)
                    || item.Description.Contains(partialNameOrDescription));

            return resultListQuery.ToList();

        }

    }
}