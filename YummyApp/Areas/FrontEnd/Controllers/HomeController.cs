using Microsoft.AspNetCore.Mvc;

namespace YummyApp.Areas.FrontEnd.Controllers
{
    [Area("FrontEnd")]
    public class HomeController : Controller
    {
        public IActionResult Temp1()
        {
            return View();
        }      
        public IActionResult Temp2()
        {
            return View();
        } 
        public IActionResult Temp3()
        {
            return View();
        }
    }
}
