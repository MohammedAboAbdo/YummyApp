namespace YummyApp.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Meal> Meals { get; set; }

    }
}
