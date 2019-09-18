using BurgerShack.Interfaces;

namespace BurgerShack.Models
{
    public enum DrinkSizes
    {
        Small = 1,
        Medium,
        Large
    }
    public class Drink : IItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DrinkSizes Size { get; set; }
    }
}