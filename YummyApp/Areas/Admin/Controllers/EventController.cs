using Microsoft.AspNetCore.Mvc;
using YummyApp.Areas.Admin.ViewModels;
using YummyApp.Data;
using YummyApp.Models;

namespace YummyApp.Areas.Admin.Controllers
{
    public class EventController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EventController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostEnvironment;
        }




        //List All Of Events
        public IActionResult Index()
        {
            var events = _context.events.ToList();

            return View(events);
        }

        // Add an event
        [HttpGet]
        public IActionResult Add()
        {

            return View();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddEventVM eventVM)
        {
            if (ModelState.IsValid)
            {
                Event NewEvent = new()
                {
                    Title = eventVM.Title,
                    Price = eventVM.Price,
                    ShortDesc = eventVM.ShortDesc,
                    EventDate = Convert.ToDateTime(eventVM.Date)
                };

                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(eventVM.Image.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                // {serverlocation}\Images\0f8fad5b-d9cb-469f-a165-70867728950e.jpg

                eventVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                NewEvent.ImageName = uniqueName;

                _context.events.Add(NewEvent);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
                return View(eventVM);

        }


        // Details

        public IActionResult Details(int id)
        {
            var eventExists = _context.events.Find(id);
            if (eventExists == null)
                return NotFound();
            else
                return View(eventExists);
        }


        // Edit an event
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var eventExists = _context.events.Find(id);
            if (eventExists == null)
                return NotFound();
            else
                return View(new EditEventVM
                {
                    Title = eventExists.Title,
                    Price = eventExists.Price,
                    ShortDesc = eventExists.ShortDesc,
                    Date = eventExists.EventDate.ToString("dd/MM/yyyy"),
                    ImageName = eventExists.ImageName,
                });
        }

        [HttpPost]
        public IActionResult Edit(int id, EditEventVM editEventVM)
        {
            var eventExists = _context.events.Find(id);
            if (eventExists == null)
                return NotFound();
            else
            {
                if (ModelState.IsValid)
                {
                    eventExists.Title = editEventVM.Title;
                    eventExists.Price = editEventVM.Price;
                    eventExists.ShortDesc = editEventVM.ShortDesc;

                    eventExists.EventDate = Convert.ToDateTime(editEventVM.Date);

                    if (editEventVM.Image != null)
                    {
                        eventExists.ImageName = ImageUploader.Upload(_hostingEnvironment.WebRootPath, editEventVM.Image);
                    }

                    _context.events.Update(eventExists);
                    _context.SaveChanges();

                    TempData["EditSuccessfully"] = "Event edited successfully";

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(editEventVM);

            }
        }



        // Delete an event
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var eventExists = _context.events.Find(id);
            if (eventExists == null)
                return NotFound();
            else
            {
                _context.events.Remove(eventExists);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Json(new { id = id, message = "Deleted Successfully" });
            }
        }

    }
}
