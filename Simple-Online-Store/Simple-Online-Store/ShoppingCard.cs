using System.Collections.Generic;
using System.Text;

namespace Online_Store
{
    public class ShoppingCard
    {
        public ShoppingCard()
        {
            Items = new List<Item>();
        }
        public List<Item> Items { get; set; }

        public static StringBuilder ReceiptAppend(List<Item> items)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int counter = 0;

            foreach (var item in items)
            {
                stringBuilder.AppendLine(($"{++counter}.{item.Name}, {item.Description}, {item.Price}"));
            }

            return stringBuilder;
        }
    }
}