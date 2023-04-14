using Microsoft.AspNetCore.Mvc;
using YummyApp.Data;
using YummyApp.Models;
using YummyApp.ViewModels;

namespace YummyApp.Controllers
{
    public class ContactController : Controller
    {
        public ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(ContactVM contact)
        {

            if (ModelState.IsValid)
            {
                _context.contacts.Add(new Contact
                {
                    Name = contact.Name,
                    Body = contact.Body,
                    Email = contact.Email,
                    Subject = contact.Subject
                });

                _context.SaveChanges();

                return RedirectToAction("Index", new { message = "Success" });

            }
            return View(contact);

        }
    }
}
