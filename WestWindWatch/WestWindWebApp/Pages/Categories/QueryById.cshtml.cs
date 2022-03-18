using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages.Categories
{
    public class QueryByIdModel : PageModel
    {

        // Define a readonly field for Category Services
        private readonly CategoryServices _categoryServices;

        // Define a greedy constructor with a CategoryServices that is injected by the container
        public QueryByIdModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // Define an auto-implemented property for feedback messages
        [TempData]
        public string FeedbackMessage { get; set; }

        // Define an auto-implemented property for the search value
        [BindProperty(SupportsGet = true)] // allows this porperty to match to a routing pro
        public int SearchId { get; set; }

        // Define an auto-implemented property for the search result
        public Category SearchSingleResult { get; set; }

        public void OnGet()
        {
            if (SearchId > 0)
            {
                SearchSingleResult = _categoryServices.Category_GetById(SearchId);
                if(SearchSingleResult == null)
                {
                    FeedbackMessage = $"No result returned for category id {SearchId}.";
                }
                else
                {
                    FeedbackMessage = $"CategoryId: {SearchSingleResult.CategoryID} <br />" +
                        $"CategoryName: {SearchSingleResult.CategoryName} <br />" +
                        $"Description: {SearchSingleResult.Description}";
                }
            }
        }

        public IActionResult OnPostFetch()
        {
            // Check if the search value is valid
            if(SearchId <= 0)
            {
                FeedbackMessage = "Required: Enter a category id to search for";
            }

            return RedirectToPage(new {SearchId = SearchId});
        }
    }
}
