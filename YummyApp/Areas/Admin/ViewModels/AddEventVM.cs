using System.ComponentModel.DataAnnotations;

namespace YummyApp.Areas.Admin.ViewModels
{
    public class AddEventVM
    {

        [Required(ErrorMessage = "TitleIsRequired")]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "PriceIsRequired")]
        [Display(Name = "Price")]
        public double Price { get; set; }


        [Required(ErrorMessage = "ShortIsRequired")]
        [Display(Name = "Short Description")]
        public string ShortDesc { get; set; }


        [Required(ErrorMessage = "ImageIsRequired")]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }


        [Required(ErrorMessage = "DateIsRequired")]
        [Display(Name = "Date")]
        public string Date { get; set; }


    }
}
