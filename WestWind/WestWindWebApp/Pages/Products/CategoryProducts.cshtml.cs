using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL; // for CategoryServices, ProductServices
using WestWindSystem.Entities; // for Category

namespace WestWindWebApp.Pages.Products
{
    public class CategoryProductsModel : PageModel
    {
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;

        public CategoryProductsModel(CategoryServices categoryServices, ProductServices productServices, SupplierServices supplierServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;

            SupplierList = _supplierServices.Supplier_List();
        }

        public List<Category> CategoryList { get; private set; } = new();

        public List<Product> ProductQueryList { get; set; } = new();

        public List<Supplier> SupplierList { get; set;}

        // 2 way property meaning that you are able to change it and receive the value
        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryID { get; set; }

        [TempData]
        public string FeedbackMessage { get; set; }

        public void OnGet()
        {
            // when the page loads, a get request will be sent to get the category list
            CategoryList = _categoryServices.Category_List();
            
            if(SelectedCategoryID > 0)
            {
                ProductQueryList = _productServices.Product_GetByCategoryID(SelectedCategoryID);
                FeedbackMessage = $"Query returned {ProductQueryList.Count} record(s)";
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
