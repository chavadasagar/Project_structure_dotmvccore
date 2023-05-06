using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class authController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
