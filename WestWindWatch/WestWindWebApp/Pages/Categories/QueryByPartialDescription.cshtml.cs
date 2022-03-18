using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages.Categories
{
    public class QueryByPartialDescriptionModel : PageModel
    {

        // Define a readonly field for Category Services
        private readonly CategoryServices _categoryServices;

        public QueryByPartialDescriptionModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        
        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public List<Category> SearchResultList { get; set; } = new();

        public IActionResult OnPostFetch()
        {
            if(string.IsNullOrWhiteSpace(SearchValue))
            {
                FeedbackMessage = "Search value is required";
            }

            return RedirectToPage(new { SearchValue = SearchValue });
        }

        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            SearchResultList.Clear();
            ModelState.Clear();
            return RedirectToPage();
        }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(SearchValue))
            {
                SearchResultList = _categoryServices.Category_GetByPartialDescription(SearchValue);
                if(SearchResultList.Count == 0)
                {
                    FeedbackMessage = "No results returned.";
                }
            }
        }
    }
}
