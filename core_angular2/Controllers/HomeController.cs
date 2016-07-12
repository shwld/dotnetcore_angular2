using Microsoft.AspNetCore.Mvc;

namespace core_angular2.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
