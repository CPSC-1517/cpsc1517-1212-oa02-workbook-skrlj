using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Add namespaces for WestWindSystem class library for BLL classes and entity class
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion


namespace WestWindWebApp.Pages.Categories
{
    public class QueryModel : PageModel
    {
        #region Define a CategoryServices field and initialize it using constructor injection
        private readonly CategoryServices _categoryServices;
        public QueryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion


        #region Define properties for data the web page needs to access
        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public List<Category> CategoryQueryResultList { get; set; } = new();

        #endregion

        #region Define page handlers to handle form submissions

        public IActionResult OnPostSearch() // This method gets executed when asp-page-handler="Search"
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
            {
                FeedbackMessage = "A search value is required.";
            }
            return RedirectToPage(new { SearchValue = SearchValue });
        }
        public IActionResult OnPostClear() // This method gets executed when asp-page-handler="Clear"
        {
            FeedbackMessage = "";
            ModelState.Clear();
            CategoryQueryResultList.Clear();
            return RedirectToPage(new { SearchValue = (string?)null });
        }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(SearchValue))
            {
                CategoryQueryResultList = _categoryServices.Category_GetByPartialCategoryNameOrDescription(SearchValue);
                FeedbackMessage = $"Search returned {CategoryQueryResultList.Count} result(s).";
            }
        }

        #endregion
    }
}