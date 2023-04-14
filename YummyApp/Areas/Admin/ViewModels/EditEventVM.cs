namespace YummyApp.Areas.Admin.ViewModels
{
    public class EditEventVM
    {

        public string Title { get; set; }

        public double Price { get; set; }

        public string ShortDesc { get; set; }

        public string? ImageName { get; set; }

        public IFormFile? Image { get; set; }

        public string Date { get; set; }

    }
}
