using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Store
{
    class Catalog
    {
        public Catalog()
        {
            //creating a dictionary using collection-initializer syntax
            Items = new Dictionary<int, Item>()
            {
                {1,  new Item("pijama", "1m i 20cm" ,12.50m, ItemCategory.Clothing)},
                {2,  new Item("mouse", "the mouse has LED ligths" ,17.50m, ItemCategory.Electronics)},
                {3,  new Item("obuwki", "41 nomer" ,10.50m, ItemCategory.Clothing)},
                {4,  new Item("kolan", "1m" ,5.50m, ItemCategory.Clothing)},
                {5,  new Item("maratonki", "45 nomer" ,102, ItemCategory.Clothing)},
                {6,  new Item("teniska", "L" ,17.80m, ItemCategory.Clothing)},
                {7,  new Item("riza", "41 nomer" ,11.10m, ItemCategory.Clothing)},
                {8,  new Item("book", "100pages" ,5.90m, ItemCategory.Books)},
            };
        }
        public Dictionary<int, Item> Items { get; set; }

        public void PrintItems(Dictionary<int, Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}. {items[item.Key].Name}, {items[item.Key].Description}, {items[item.Key].Price}");
            }
        }
        //here is a method with the same name -> overload -> Polymorphism
        public void PrintItems(List<Item> items)
        {
            int i = 1;
            foreach (var item in items)
            {
                Console.WriteLine($"{i++}. {item.Name}, {item.Description}, {item.Price}");
            }
        }
    }
}
