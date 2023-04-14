using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using YummyApp.Data;
using YummyApp.Models;
using YummyApp.ViewModels;

namespace YummyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer _Localizer;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IStringLocalizer<HomeController> stringLocalizer
            )
        {
            _signInManager = signInManager;
            _context = context;
            _Localizer = stringLocalizer;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var events = _context.events.ToList();

            ViewBag.Welcome = _Localizer["Welcome"].Value;

            return View(events);
        }

        [HttpGet]
        [Route("Login")]
        //[AllowAnonymous]
        public IActionResult Login(string ReturnUrl = null)
        {
            ViewData["ReturnUrl"] = ReturnUrl;

            return View("Login");
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, // AspCultureName 
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }



        [HttpGet]
        [Route("LogOut")]
        //[AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Route("Denied")]
        public IActionResult Denied()
        {
            return View("Denied");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.2");
                return View();
            }

            //Check user type  to redirect to the correct page

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (result.Succeeded)
            {
                //return RedirectToAction("Index", "Home", new { area = "Admin" });
                //if (user.userType == UserType.Administrator)
                //{
                return LocalRedirect(loginVM.ReturnUrl);
                //}
            }
            else
            {
                //ViewData["ReturnUrl"] = loginVM.ReturnUrl;
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}