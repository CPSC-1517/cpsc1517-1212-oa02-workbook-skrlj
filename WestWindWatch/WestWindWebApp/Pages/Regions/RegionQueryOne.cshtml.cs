using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;// for RegionServices
using WestWindSystem.Entities;  // for Region
namespace WestwindWebApp.Pages.Regions
{
    public class RegionQueryOneModel : PageModel
    {
        #region Inject an RegionServices into the constructor of the page model
        private readonly RegionServices _regionServices;
        public RegionQueryOneModel(RegionServices regionServices)
        {
            _regionServices = regionServices;
        }
        #endregion
        #region Define properties required to search for a single Region by RegionID
        [TempData]
        public string FeedbackMessage { get; set; }
        [BindProperty(SupportsGet = true)]  // Bind this property using a route name or a query parameter name
        public int RegionID { get; set; }
        public Region QuerySingleResult { get; set; }
        #endregion
        #region Define a page handler to perform the search by Region By RegionID
        public IActionResult OnPostSearch()
        {
            // See an error if RegionID is not valid
            if (RegionID < 1)
            {
                FeedbackMessage = "RegionID is required and must greater than zero.";
            }
            // Redirect to the same page and pass the routeValue RegionID
            return RedirectToPage(new { RegionID = RegionID });
        }
        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            ModelState.Clear();
            return RedirectToPage(new { RegionID = (int?)null });
        }
        #endregion
        public void OnGet()
        {
        }
    }
}