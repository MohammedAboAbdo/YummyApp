using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace YummyApp.Areas.Admin.Controllers
{

    public class HomeController : AdminBaseController
    {
        private readonly IStringLocalizer<HomeController> _Localizer;

        public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        {
            _Localizer = stringLocalizer;
        }
        public IActionResult Index()
        {

            //ViewBag.Welcome = _Localizer.GetString("Welcome");
            ViewBag.Welcome = _Localizer["Welcome"];
            return View();
        }
    }
}
