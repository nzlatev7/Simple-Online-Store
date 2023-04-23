using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Online_Store
{
    class Customer
    {
        public Customer(string name, int age, decimal money)
        {
            Name = name;
            Age = age;
            Money = money;
            ShoppingCard = new ShoppingCard();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Money { get; set; }

        public ShoppingCard ShoppingCard { get; set; }

        public List<Item> ViewMyShoppingCard()
        {
            return ShoppingCard.Items;
        }
        public virtual decimal CostOfShoppingCard()
        {
            decimal cost = ShoppingCard.Items.Sum(x => x.Price);
            return cost;
        }
    }
}