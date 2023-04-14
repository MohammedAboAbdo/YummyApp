namespace YummyApp.Areas.Admin.ViewModels
{
    public class CreateChefVM
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Files/Images/1231293123.jpg
        public IFormFile Image { get; set; }

        public string? JobTitle { get; set; }

        public string? Desc { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }


    }
}
