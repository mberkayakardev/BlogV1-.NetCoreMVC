using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class Account : Controller
    {
        public IActionResult Login()
        {
            return View();
        }             
    }
}
