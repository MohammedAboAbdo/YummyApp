using System.ComponentModel.DataAnnotations;

namespace YummyApp.ViewModels
{
    public class ContactVM
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Body { get; set; }

    }
}
