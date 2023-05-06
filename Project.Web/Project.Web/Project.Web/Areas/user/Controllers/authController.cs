using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Areas.user.Controllers
{
    [Area("user")]
    public class authController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
