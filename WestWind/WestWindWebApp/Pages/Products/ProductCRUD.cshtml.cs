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

        public void OnGet()
        {
        }
    }
}
