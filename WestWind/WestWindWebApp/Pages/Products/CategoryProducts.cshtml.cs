using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL; // for CategoryServices, ProductServices
using WestWindSystem.Entities; // for Category
using Microsoft.Extensions.Configuration; // for Configuration
using WestWindWebApp.Helpers; // for Paginator

namespace WestWindWebApp.Pages.Products
{
    public class CategoryProductsModel : PageModel
    {
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;
        private readonly IConfiguration _configuration;

        public CategoryProductsModel(CategoryServices categoryServices, ProductServices productServices, SupplierServices supplierServices, IConfiguration configuration)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;
            _configuration = configuration;

            PAGE_SIZE = configuration.GetValue("PageSize", 3);

            SupplierList = _supplierServices.Supplier_List();
        }

        #region Paginator
        //my desired page size
        //private const int PAGE_SIZE = 5;
        private readonly int PAGE_SIZE;
        //be able to hold an instance of the Paginator
        public Paginator Pager { get; set; }
        #endregion

        public List<Category> CategoryList { get; private set; } = new();

        public List<Product> ProductQueryList { get; set; } = new();

        public List<Supplier> SupplierList { get; set;}

        // 2 way property meaning that you are able to change it and receive the value
        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryID { get; set; }

        [TempData]
        public string FeedbackMessage { get; set; }

        public void OnGet(int? currentPage)
        {
            // when the page loads, a get request will be sent to get the category list
            CategoryList = _categoryServices.Category_List();
            
            if(SelectedCategoryID > 0)
            {
                //ProductQueryList = _productServices.Product_GetByCategoryID(SelectedCategoryID);
                //FeedbackMessage = $"Query returned {ProductQueryList.Count} record(s)";
                //determine the current page number
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                //setup the current state of the paginator (sizing)
                PageState current = new(pagenumber, PAGE_SIZE);
                //temporary local integer to hold the results of the query's total collection size
                // this will be need by the Paginator during the paginator's execution
                int totalcount;



                ProductQueryList = _productServices.Product_GetByCategoryID(
                SelectedCategoryID,
                PAGE_SIZE,
                pagenumber,
                out totalcount);

                //create the needed Pagnator instance
                Pager = new Paginator(totalcount, current);
            }
        }

        public IActionResult OnPostFetch ()
        {
            return RedirectToPage("/Products/CategoryProducts", new { SelectedCategoryID = SelectedCategoryID });
        }

        public void OnPostClear()
        {

        }

        public void OnPostNew()
        {

        }
    }
}
