namespace YummyApp.Areas.Chef.ViewModels
{
    public class EditMealVM
    {
        public string Name { get; set; }

        public double Price { get; set; }

        //public string ImageName { get; set; }
        public string Ingredients { get; set; }

        public int CategoryId { get; set; }

        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
