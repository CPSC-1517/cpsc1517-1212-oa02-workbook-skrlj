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

        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
