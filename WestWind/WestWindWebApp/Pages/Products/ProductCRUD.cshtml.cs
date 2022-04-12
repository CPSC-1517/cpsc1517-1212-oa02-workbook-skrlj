using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages.Products
{
    public class ProductCRUDModel : PageModel
    {
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;

        public ProductCRUDModel(CategoryServices categoryServices, ProductServices productServices, SupplierServices supplierServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;

            SupplierList = _supplierServices.Supplier_List();
            CategoryList = _categoryServices.Category_List();
        }

        public List<Supplier> SupplierList { get; private set; }

        [BindProperty]
        public int? SelectedSupplierID { get; set; }

        public List<Category> CategoryList { get; private set; }

        [BindProperty]
        public int? SelectedCategoryID { get; set; }

        [BindProperty]
        public Product CurrentProduct { get; set; }

        [TempData]
        public string FeedbackMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostNew()
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int newProductID = _productServices.Product_AddProduct(CurrentProduct);
                    FeedbackMessage = $"ProductID ({newProductID}) has been added to the system";
                    RedirectToPage(new { productID = newProductID });
                }

                catch (Exception ex)
                {
                    FeedbackMessage = GetInnerException(ex).Message;
                }
            }
            return Page();
        }
        
        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            ModelState.Clear();
            return RedirectToPage(new { productID = (int?) null });
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/Products/CategoryProducts");
        }

        private Exception GetInnerException(Exception ex)
        {
            //drill down to the REAL ERROR message
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
