using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YummyApp.Areas.Admin.ViewModels;
using YummyApp.Data;

namespace YummyApp.Areas.Admin.Controllers
{

    public class ChefController : AdminBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ChefController(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var listOfUsers = _userManager.Users.Where(x => x.userType == UserType.Chef).ToList();
            return View(listOfUsers);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateChefVM createChefVM)
        {

            if (ModelState.IsValid)
            {

                var checkUserExists = _userManager.Users.Where(x => x.Email == createChefVM.Email).FirstOrDefault();
                if (checkUserExists != null)
                {
                    ModelState.AddModelError("", "Email Already exists");
                    return View();
                }

                var newUser = new ApplicationUser
                {
                    FirstName = createChefVM.FirstName,
                    LastName = createChefVM.LastName,
                    JobTitle = createChefVM.JobTitle,
                    Desc = createChefVM.Desc,
                    Email = createChefVM.Email,
                    UserName = createChefVM.UserName,
                    userType = UserType.Chef
                };

                var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(createChefVM.Image.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);

                createChefVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                newUser.ImageName = uniqueName;



                var result = await _userManager.CreateAsync(newUser, createChefVM.Password);

                if (result.Succeeded)
                {
                    var resultRole = await _userManager.AddToRoleAsync(newUser, "Chef");
                    TempData["UserCreated"] = "User has been created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
            }

            return View();
        }


        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    TempData["ErrorDeleting"] = "Success";

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorDeleting"] = "Error Deleting";

                    return RedirectToAction(nameof(Index));

                }

            }
        }

    }
}
