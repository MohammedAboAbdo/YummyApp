using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YummyApp.Areas.Chef.ViewModels;
using YummyApp.Data;
using YummyApp.Models;

namespace YummyApp.Areas.Chef.Controllers
{

    public class MealsController : ChefBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MealsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.userManager = userManager;
            _hostEnvironment = webHostEnvironment;
        }

        // GET: Chef/Meals
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);

            var applicationDbContext = _context.meals
                .Where(x => x.ChefId == currentUser.Id)
                .Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Chef/Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.meals == null)
            {
                return NotFound();
            }

            var meal = await _context.meals
                .Include(m => m.ApplicationUser)
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // GET: Chef/Meals/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.menuCategories, "Id", "Name");
            return View();
        }

        // POST: Chef/Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMealVM mealVM)
        {
            if (ModelState.IsValid)
            {

                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);

                Meal meal = new Meal
                {
                    CategoryId = mealVM.CategoryId,
                    ChefId = currentUser.Id,
                    Ingredients = mealVM.Ingredients,
                    Name = mealVM.Name,
                    Price = mealVM.Price

                };


                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(mealVM.Image.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);


                mealVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                meal.ImageName = uniqueName;

                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.menuCategories, "Id", "Id", mealVM.CategoryId);

            return View(mealVM);
        }

        // GET: Chef/Meals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.meals == null)
            {
                return NotFound();
            }

            var meal = await _context.meals.FindAsync(id);

            EditMealVM editMealVm = new EditMealVM
            {
                CategoryId = meal.CategoryId,
                ImageName = meal.ImageName,
                Ingredients = meal.Ingredients,
                Name = meal.Name,
                Price = meal.Price
            };

            if (meal == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.menuCategories, "Id", "Name", meal.CategoryId);
            return View(editMealVm);
        }

        // POST: Chef/Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditMealVM editMealVM)
        {

            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);

            var mealExists = await _context.meals
                .Where(x => x.ChefId == currentUser.Id && x.Id == id)
                .FirstOrDefaultAsync();

            if (mealExists == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                mealExists.CategoryId = editMealVM.CategoryId;
                mealExists.Ingredients = editMealVM.Ingredients;
                mealExists.Name = editMealVM.Name;
                mealExists.Price = editMealVM.Price;

                if (editMealVM.Image != null)
                {


                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(editMealVM.Image.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);


                    editMealVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    mealExists.ImageName = uniqueName;
                }


                _context.meals.Update(mealExists);
                await _context.SaveChangesAsync();

                //try
                //{
                //    _context.Update(meal);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!MealExists(meal.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}

                return RedirectToAction(nameof(Index));
            }


            ViewData["CategoryId"] = new SelectList(_context.menuCategories, "Id", "Name", editMealVM.CategoryId);
            return View(editMealVM);
        }

        // GET: Chef/Meals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.meals == null)
            {
                return NotFound();
            }

            var meal = await _context.meals
                .Include(m => m.ApplicationUser)
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Chef/Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.meals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.meals'  is null.");
            }
            var meal = await _context.meals.FindAsync(id);
            if (meal != null)
            {
                _context.meals.Remove(meal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return (_context.meals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
