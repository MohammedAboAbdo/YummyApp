using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyApp.Areas.Admin.ViewModels;
using YummyApp.Data;

namespace YummyApp.Areas.Admin.Controllers
{
    public class GalleryController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _HostEnvironment;

        public GalleryController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _HostEnvironment = webHostEnvironment;
        }



        public IActionResult Index()
        {
            var list = _context.photoAlbums.Include(x => x.photos).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(AddPhotoAlbumVM addPhotoAlbumVM)
        {
            var photoAlbum = new Models.PhotoAlbum { Title = addPhotoAlbumVM.Title };
            _context.photoAlbums.Add(photoAlbum);
            _context.SaveChanges();

            foreach (IFormFile Image in addPhotoAlbumVM.Images)
            {
                var ImageName = ImageUploader.Upload(_HostEnvironment.WebRootPath, Image);
                _context.photos.Add(new Models.Photo { ImageName = ImageName, PhotoAlbumId = photoAlbum.Id });
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
