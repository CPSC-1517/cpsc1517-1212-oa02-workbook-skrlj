using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestWindSystem.BLL; // for CategoryServices
using WestWindSystem.Entities; // for Category 

namespace WestWindWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        #region use dependency injection to assign value to categoryServices
        private readonly CategoryServices _categoryService;

        public IndexModel(CategoryServices categoryServices)
        {
            _categoryService = categoryServices;
        }
        #endregion

        #region properties accessed by web page
        public List<Category> CategoryList { get; set; } = new();
        #endregion

        public void OnGet() // this method gets executed in response to an HTTP GET request
        {
            CategoryList = _categoryService.Category_List();
        }
    }
}
