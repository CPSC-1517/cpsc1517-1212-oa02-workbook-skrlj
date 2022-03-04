using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebAppDemo.Pages
{
    public class FormFieldControlsModel : PageModel
    {
        // Define an auto-implemented property for feedback messages
        public string Message { get; set; }

        [BindProperty] // Bind a HTML form field to this property
        // Define an auto-implemented property for username
        public string Username { get; set; }

        // Define an auto-implemented property for password
        [BindProperty]
        public string Password { get; set; }

        // Define an auto-implemented property for confirmed password
        [BindProperty]
        public string ConfirmPassword { get; set; }

        // Create a method that will handle a HTTP post request. **The method must start with "On", followed by the method (Get, Post) to handle**
        public void OnPost()
        {
            // Check if the password matches the confirm password
            if(Password == ConfirmPassword)
            {
                Message = $"You submitted the following: {Username}, {Password}";
            }
            else
            {
                Message = "The password and confirm password does not match";
            }
        }

        public void OnGet()
        {
        }
    }
}
