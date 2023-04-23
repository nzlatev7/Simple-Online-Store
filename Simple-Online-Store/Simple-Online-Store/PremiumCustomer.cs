using Online_Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Online_Store
{
    // this is an example of inheritance
    // the benefit of premium customer is that specific property for discount
    class PremiumCustomer : Customer
    {
        public PremiumCustomer(string name, int age, decimal money, int discountPercentage) : base(name, age, money)
        {
            DiscountPercentage = discountPercentage;
        }

        public int DiscountPercentage { get; set; }

        public override decimal CostOfShoppingCard()
        {
            decimal cost = ShoppingCard.Items.Sum(x => x.Price) - ShoppingCard.Items.Sum(x => x.Price) * DiscountPercentage / 100;
            return cost;
        }
    }
}
