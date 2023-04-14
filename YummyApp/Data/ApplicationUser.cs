using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YummyApp.Data
{
    public class ApplicationUser : IdentityUser
    {

        [StringLength(256)]
        public string FirstName { get; set; }
        [StringLength(256)]
        public string LastName { get; set; }

        //Files/Images/1231293123.jpg
        public string? ImageName { get; set; }


        [Column(TypeName = "nvarchar(24)")]
        public UserType userType { get; set; }

        public string? JobTitle { get; set; }

        public string? Desc { get; set; }

        

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


    }

    public enum UserType
    {
        Administrator,
        Chef,
        User
    }
}
