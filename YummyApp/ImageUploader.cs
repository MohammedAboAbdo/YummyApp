namespace YummyApp
{
    public class ImageUploader
    {
        public static string Upload(string WebPath, IFormFile file)
        {
            var uploadFolder = Path.Combine(WebPath, "Images");
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueName);

            file.CopyTo(new FileStream(filePath, FileMode.Create));

            return uniqueName;

        }
    }
}
