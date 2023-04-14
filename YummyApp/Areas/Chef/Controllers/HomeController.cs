using Microsoft.AspNetCore.Mvc;

namespace YummyApp.Areas.Chef.Controllers
{

    public class HomeController : ChefBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
