using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Add namespaces for WestWindSystem class library for BLL classes and entity class
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WestWindWebApp.Helpers;
#endregion

namespace WestWindWebApp.Pages.Products
{
    public class QueryModel : PageModel
    {
        #region Define a CategoryServices field and ProductServices field and initialize it using constructor injection
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        public QueryModel(CategoryServices categoryServices, ProductServices productServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
        }
        #endregion

        #region Define properties for data the web page needs to access
        [TempData] // TempData is useful for redirection, when data is needed for more than a single request.
        public string FeedbackMessage { get; set; }
        public List<Category> CategoryList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductNameSearchValue { get; set; }

        public List<Product> ProductQueryResultList { get; set; } = new();
        #endregion

        // Step 3
        #region Paginator
        //my desired page size
        private const int PAGE_SIZE = 5;
        //be able to hold an instance of the Paginator
        public Paginator Pager { get; set; }
        #endregion

        public void OnGet(int? currentPage)
        {
            CategoryList = _categoryServices.Category_List();

            if (SelectedCategoryID > 0)
            {
                ProductQueryResultList = _productServices.Product_GetByCategoryID(SelectedCategoryID);
                FeedbackMessage = $"Search returned {ProductQueryResultList.Count} result(s).";
            }
            else if (!string.IsNullOrWhiteSpace(ProductNameSearchValue))
            {
                //ProductQueryResultList = _productServices.Product_GetByPartialProductName(ProductNameSearchValue);

                // Step 4
                //determine the current page number
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                //setup the current state of the paginator (sizing)
                PageState current = new(pagenumber, PAGE_SIZE);
                //temporary local integer to hold the results of the query's total collection size
                //  this will be need by the Paginator during the paginator's execution
                int totalcount;
                ProductQueryResultList = _productServices.Product_GetByPartialProductName(ProductNameSearchValue, PAGE_SIZE, pagenumber, out totalcount);
                //create the needed Pagnator instance
                Pager = new Paginator(totalcount, current);


                FeedbackMessage = $"Search returned {ProductQueryResultList.Count} result(s).";
            }

        }

        public IActionResult OnPostSearchByCategoryID()
        {
            if (SelectedCategoryID == 0)
            {
                FeedbackMessage = "You must select a category";
            }
            return RedirectToPage(new { SelectedCategoryID = SelectedCategoryID });
        }

        public IActionResult OnPostSearchByProductName()
        {
            if (string.IsNullOrWhiteSpace(ProductNameSearchValue))
            {
                FeedbackMessage = "You must enter a product name to search for.";
            }
            return RedirectToPage(new { ProductNameSearchValue = ProductNameSearchValue });
        }

        public IActionResult OnPostClear() // This method gets executed when asp-page-handler="Clear"
        {
            FeedbackMessage = "";
            ModelState.Clear();
            ProductQueryResultList.Clear();
            return RedirectToPage();
        }
    }
}