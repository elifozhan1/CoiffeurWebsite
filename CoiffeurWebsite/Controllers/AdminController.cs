using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoiffeurWebsite.Controllers
{
    public class AdminController : Controller
    {

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult YardimSayfasi()
        {
            return View();
        }
    }
}