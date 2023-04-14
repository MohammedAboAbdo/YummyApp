using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyApp.Data;

namespace YummyApp.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var galleryList = _context.photoAlbums.Include(x => x.photos).ToList();
            return View(galleryList);
        }

        [HttpGet]
        public IActionResult Photos(int id)
        {
            var photos = _context.photos.Where(x => x.PhotoAlbumId == id).ToList();

            return View(photos);
        }
    }
}
