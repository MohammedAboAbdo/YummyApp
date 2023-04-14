using Microsoft.AspNetCore.Mvc;
using YummyApp.Data;
using YummyApp.ViewModels;

namespace YummyApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() 
        {
            var menuList = _context.menuCategories.ToList();
            var lastMeals = _context.meals.Take(3).OrderBy(x => x.Id).ToList();

            MenuCategoryVM menuCategoryVM = new MenuCategoryVM
            {
                meals = lastMeals,
                menuCategory = menuList
            };
            return View(menuCategoryVM);
        }

         // SPA 


        [HttpGet]
        public IActionResult ListMeals(int id)
        {
            var list = _context.meals.Where(x => x.CategoryId == id).ToList();
          
            return PartialView("_MealList", list);
        }
    }
}
