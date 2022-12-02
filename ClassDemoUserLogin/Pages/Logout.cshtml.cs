using ClassDemoUserLogin.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoUserLogin.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IUserService _service;

        public LogoutModel(IUserService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            _service.UserLoggedOut();
            return RedirectToPage("Index");
        }
    }
}
