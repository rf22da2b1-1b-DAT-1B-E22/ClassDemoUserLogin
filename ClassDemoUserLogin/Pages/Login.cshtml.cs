using ClassDemoUserLogin.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ClassDemoUserLogin.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _service;

        public LoginModel(IUserService service)
        {
            _service = service;
        }




        [BindProperty]
        [Required]
        [StringLength(30,MinimumLength = 3, ErrorMessage = "Der skal v�re et navn")]
        public String Name { get; set; }

        [BindProperty]
        [Required]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Password skal v�re mere end 6 tegn")]
        public String Password1 { get; set; }

        [BindProperty]
        [Required]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Password skal v�re mere end 6 tegn")]
        public String Password2 { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Password1 != Password2)
            {
                return Page();
            }

            if (Name == "admin" && Password1 == "secret")
            {
                _service.SetUserLoggedIn(Name, true);
            }
            else
            {
                _service.SetUserLoggedIn(Name, false);
            }

            return RedirectToPage("Index");
        }
    }
}
