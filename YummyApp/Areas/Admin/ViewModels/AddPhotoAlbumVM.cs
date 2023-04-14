namespace YummyApp.Areas.Admin.ViewModels
{
    public class AddPhotoAlbumVM
    {

        public string Title { get; set; }
        
        public List<IFormFile> Images { get; set; }

    }
}
