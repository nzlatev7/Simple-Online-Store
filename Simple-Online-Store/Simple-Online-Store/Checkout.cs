using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Online_Store
{
    class Checkout
    {
        public decimal CalculateTotalCost(List<Item> items)
        {
            decimal totalCost = items.Sum(x => x.Price);
            return totalCost;
        }
    }
}
