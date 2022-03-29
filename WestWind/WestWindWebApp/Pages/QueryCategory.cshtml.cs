using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Add namespaces for access BLL and Entities
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages
{
    public class QueryCategoryModel : PageModel
    {
        // Declare constructor a dependency of CategoryServices
        private readonly CategoryServices _categoryServices;
        public QueryCategoryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // Define Properties for data the web page needs to access
        [TempData]
        public string FeedbackMessage { get; set; }

        // BindProperty means that if there is a parameter in the url called "SearchValue", copy the value to the property
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public List<Category> QueryResultList { get; set; } = new();

        // Define handlers for the page 
        public IActionResult OnPostSearch()
        {
            if(string.IsNullOrEmpty(SearchValue))
            {
                FeedbackMessage = "A search value is required";
            }
            return RedirectToPage(new {SearchValue = SearchValue});
        }

        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            ModelState.Clear();
            QueryResultList.Clear();
            return RedirectToPage(new {SearchValue = (string?) null});
        }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(SearchValue))
            {
                QueryResultList = _categoryServices.Category_GetByPartialCategoryNameOrDescription(SearchValue);
                FeedbackMessage = $"Search returned {QueryResultList.Count} records";
            }
        }
    }
}
