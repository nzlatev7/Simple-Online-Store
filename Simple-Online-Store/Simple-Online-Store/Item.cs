using System;

namespace Online_Store
{
    public class Item
    {
        public Item(string name, string description, decimal price, ItemCategory category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ItemCategory Category { get; set; }

        public static void Print(Item item)
        {
            Console.WriteLine($"{item.Name}, {item.Description}, {item.Price}");
        }
    }
    public enum ItemCategory
    {
        Clothing,
        Electronics,
        Books,
        Food,
        Home
    }
}