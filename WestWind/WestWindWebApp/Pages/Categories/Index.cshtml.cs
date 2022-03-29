using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Add namespaces for WestWindSystem class library for BLL classes and entity class
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WestWindWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        #region Define a CategoryServices field and initialize it using constructor injection
        private readonly CategoryServices _categoryServices;
        public IndexModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion

        #region Define properties for data access by the page
        [TempData]
        public string FeedbackMessage { get; set; }

        public List<Category> CategoryList { get; set; } = new();
        #endregion

        #region Define code that gets executed when the page is accessed using a HTTP GET request
        public void OnGet()
        {
            // Fetch a list of category from the database using our BLL object
            CategoryList = _categoryServices.Category_List();
        }
        #endregion

    }
}