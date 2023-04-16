using System.Collections.Generic;

namespace Online_Store
{
    public class ShoppingCard
    {
        public ShoppingCard()
        {
            Items = new List<Item>();
        }
        public List<Item> Items { get; set; }
    }
}