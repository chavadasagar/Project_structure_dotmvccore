using Microsoft.AspNetCore.Mvc;
using Project.Domain.FormClass;
using Project.Web.Migrations;

namespace Project.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                return Content("success");
            }

            return View(user);
        }
    }
}
