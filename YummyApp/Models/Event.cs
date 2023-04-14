using System.ComponentModel.DataAnnotations.Schema;

namespace YummyApp.Models
{
    public class Event
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string ShortDesc { get; set; }

        public string ImageName { get; set; }

        public DateTime EventDate { get; set; }

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
