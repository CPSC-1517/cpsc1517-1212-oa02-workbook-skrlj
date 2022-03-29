using WestWindSystem.DAL; // for WestWindContext
using WestWindSystem.Entities; // for Category

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

        // Step 2: Define query methods of the Category entity
        public List<Category> Category_List()
        {
            //IEnumerable<Category> resultListQuery = _dbContext
            //    .Categories
            //    .OrderBy(item => item.CategoryName);
            //return resultListQuery.ToList();
            return _dbContext
                .Categories
                .OrderBy(item => item.CategoryName)
                .ToList();
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