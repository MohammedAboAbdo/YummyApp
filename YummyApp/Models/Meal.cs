using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YummyApp.Data;

namespace YummyApp.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Display(Name = "Meal Name")]
        public string Name { get; set; }


        public double Price { get; set; }

        public string ImageName { get; set; }


        public string Ingredients { get; set; }



        [ForeignKey("ApplicationUser")]
        public string ChefId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        public int CategoryId { get; set; }
        public MenuCategory Category { get; set; }

        [NotMapped]
        public string PriceWithDollarSign
        {
            get
            {
                return "$" + Price;
            }
        }

    }
}
