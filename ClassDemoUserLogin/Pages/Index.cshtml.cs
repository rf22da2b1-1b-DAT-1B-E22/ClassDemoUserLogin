using ClassDemoUserLogin.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoUserLogin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _service;


        public bool IsAdmin
        {
            get
            {
                return _service.IsUserAdmin;
            }
        }

        public String Name => _service.UserName;



        public IndexModel(IUserService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            // tjek om user er logget in
            if (!_service.IsLoggedIn)
            {
                return RedirectToPage("Login");
            }

            return Page();
        }
    }
}