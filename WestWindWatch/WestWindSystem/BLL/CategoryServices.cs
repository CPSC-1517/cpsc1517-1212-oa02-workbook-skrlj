using WestWindSystem.DAL; // for WestWindContext
using WestWindSystem.Entities; // for Category

namespace WestWindSystem.BLL
{
    public class CategoryServices
    {
        #region Setup a DbContext using dependency injection
        // Define a readonly field for the database context that will be assigned a value in the constructor
        private readonly WestWindContext _context;

        internal CategoryServices(WestWindContext context)
        {
            _context = context;
        }
        #endregion

        public List<Category> Category_List()
        {
            return _context
                .Categories
                .OrderBy(currentItem => currentItem.CategoryName) // sort the results by Category Name
                .ToList();
        }

        public Category? Category_GetById(int categoryId)
        {
            return _context
                .Categories
                .Where(currentItem => currentItem.CategoryID == categoryId)
                .FirstOrDefault();
        }

        public List<Category> Category_GetByPartialDescription(string partialDescription)
        {
            return _context
                .Categories
                .Where(currentItem => currentItem.Description.Contains(partialDescription))
                .ToList();
        }
    }
}
