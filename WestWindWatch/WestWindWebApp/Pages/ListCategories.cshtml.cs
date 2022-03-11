using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL; // for CategoryServices
using WestWindSystem.Entities; // for Category

namespace WestWindWebApp.Pages
{
    public class ListCategoriesModel : PageModel
    {
        private readonly CategoryServices _categoryServices;

        public ListCategoriesModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public List<Category> WestWindCategories { get; private set; }

        public void OnGet()
        {
            WestWindCategories = _categoryServices.GetAllCategory();
        }
    }
}
