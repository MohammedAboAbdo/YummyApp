using Microsoft.AspNetCore.Mvc;
using YummyApp.Data;

namespace YummyApp.Components
{
    public class MenuCategoryViewComponent : ViewComponent 
    {
        private readonly ApplicationDbContext _context;

        public MenuCategoryViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var list = _context.menuCategories.ToList();

            return View(list);
        }

    }
}
