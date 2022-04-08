using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages.Categories
{
    public class CategoryCRUDModel : PageModel
    {
        private readonly CategoryServices _categoryServices;

        public CategoryCRUDModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // The category to create, update, or delete
        [BindProperty]
        public Category CurrentCategory { get; set; }

        [TempData]
        public string FeedbackMessage { get; set; }

        public IActionResult OnGet(int? CurrentCategoryID)
        {
            if (CurrentCategoryID == null)
            {
                CurrentCategory = new Category();
                return Page();
            }
            
            CurrentCategory = _categoryServices.Category_GetById((int)CurrentCategoryID);

            if (CurrentCategory == null)
            {
                return RedirectToPage("/Categories/Index");
            }

            return Page();
        }

        public IActionResult OnPostNew()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int categoryID = _categoryServices.Category_AddCategory(CurrentCategory);
                    FeedbackMessage = $"Successfully created category with id of {categoryID}";
                }
                catch (Exception ex)
                {
                    FeedbackMessage = $"Error creating category with exception {ex.Message}";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
            return RedirectToPage("/Categories/Index");
        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int rowsUpdated = _categoryServices.Category_UpdateCategory(CurrentCategory);
                    FeedbackMessage = $"Successfully updated {rowsUpdated} category";
                }

                catch(Exception ex)
                {
                    FeedbackMessage = $"Error updating category with exception {ex.Message}";
                    return Page();
                }
            }

            else
            {
                return Page();
            }
            return RedirectToPage("/Categories/Index");
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                int rowsDeleted = _categoryServices.Category_DeleteCategory(CurrentCategory.CategoryID);
                FeedbackMessage = $"Succesfully deleted {rowsDeleted} records";
            }
            catch(Exception ex)
            {
                FeedbackMessage = $"Error deleting category with exception: {ex.Message}";
                return Page();
            }
            return RedirectToPage("/Categories/Index");
        }

        public IActionResult OnPostClear()
        {
            if (CurrentCategory.CategoryID == 0)
            {
                FeedbackMessage = "";
                ModelState.Clear();
                return RedirectToPage("/Categories/CategoryCRUD");
            }
            else
            {
                return RedirectToPage("/Categories/Index");
            }
        }
    }
}
