using Simple_Online_Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            //all shooping items
            Dictionary<int, Item> items = Catalog.Items;

            //create a customer
            Customer customer = new Customer("Nasko", 12, 200);

            //create a premium customer, the main change here is the discount percent
            PremiumCustomer premiumCustomer = new PremiumCustomer("Pesho", 22, 12000, 10);


            // if the user have promoCode and it is correct-> this is a premium Customer
            StandardMessages.PromoCode();
            string promoCode = Console.ReadLine();

            // if the promo code is "premium" this will retun true
            bool isHavingPromoCode = promoCode == "premium" ? true : false;     
            
            //print the catalog of items
            Catalog.PrintItems(items);

            StandardMessages.TypeCommand();

            string command;
            while ((command = Console.ReadLine()) != "end with shopping")
            {
                switch (command)
                {
                    case "add item":
                        AddItem(items, customer, premiumCustomer, isHavingPromoCode);
                        break;
                    case "view my shopping card":
                        ViewShoppingCard(customer, premiumCustomer, isHavingPromoCode);
                        break;

                    // you can check your shopping card cost
                    case "cost":
                        Cost(customer, premiumCustomer, isHavingPromoCode);
                        break;

                    // with this you can search items by name
                    case "search":
                        SearchForItem(items, customer, premiumCustomer, isHavingPromoCode);
                        break;
                    case "remove item":
                        RemoveItem(customer, premiumCustomer, isHavingPromoCode);
                        break;
                    default:
                        StandardMessages.InvalidCommand();
                        break;
                }

                StandardMessages.TypeCommand();
            }

            //when we end with shopping, the items go through a checkout process, here we calulate the total cost
            decimal totalCost = TotalCost(isHavingPromoCode, customer, premiumCustomer);

            StandardMessages.TotalCost(totalCost);

            if (totalCost <= customer.Money)
            {
                StandardMessages.EndSuccessful();
            }
            else
            {
                StandardMessages.DoNotHaveEnoughMoney();
            }

            //receipt operation
            DigitalReceipt digitalReceipt = new DigitalReceipt(customer, premiumCustomer, isHavingPromoCode);
            digitalReceipt.Operation();
        }
        static void AddItem(Dictionary<int, Item> items, Customer customer, PremiumCustomer premiumCustomer, bool isHavingPromoCode)
        {
            StandardMessages.ChosingByIndex();
            int index = int.Parse(Console.ReadLine());

            //add item
            Item currentItemForAdding = items[index];

            // validate the user, add the items to the correct customer
            if (isHavingPromoCode)
            {
                premiumCustomer.ShoppingCard.Items.Add(currentItemForAdding);
            }
            else
            {
                customer.ShoppingCard.Items.Add(currentItemForAdding);
            }

            StandardMessages.Successfully("add");

            //delete the item
            items.Remove(index);

            //print the catalog of items
            Catalog.PrintItems(items);
        }
        static void ViewShoppingCard(Customer customer, PremiumCustomer premiumCustomer, bool isHavingPromoCode)
        {
            List<Item> myItems;

            // validate the user, return thr correct Items
            if (isHavingPromoCode)
            {
                // grap my items, premiumCustomer Items
                myItems = premiumCustomer.ViewMyShoppingCard();
            }
            else
            {
                // grap my items, customer Items
                myItems = customer.ViewMyShoppingCard();
            }

            if (myItems.Count == 0)
            {
                StandardMessages.EmptyShoppingCard();
            }
            else
            {
                // Here PrintItems is a method with the same name but print the List<Item>
                // method overloading -> same name with different parameters
                Catalog.PrintItems(myItems);
            }
            
        }
        static void Cost(Customer customer, PremiumCustomer premiumCustomer, bool isHavingPromoCode)
        {
            decimal cost;

            // validate the user, return thr correct cost
            if (isHavingPromoCode)
            {
                cost = premiumCustomer.CostOfShoppingCard();
            }
            else
            {
                cost = customer.CostOfShoppingCard();
            }
            StandardMessages.DisplayCost(cost);
        }
        static void SearchForItem(Dictionary<int, Item> items, Customer customer, PremiumCustomer premiumCustomer, bool isHavingPromoCode)
        {
            string item = Console.ReadLine();

            //check if the dictionary have items with name like item
            List<Item> sameItems = items.Select(x => x.Value).Where(x => x.Name == item).ToList();

            if (sameItems == null)
            {
                StandardMessages.ItemNotFound();
            }
            else
            {
                //printing the duplicates
                foreach (var currentItem in sameItems)
                {
                    Item.Print(currentItem);
                }
            }
            
        }
        static void RemoveItem(Customer customer, PremiumCustomer premiumCustomer, bool isHavingPromoCode)
        {
            List<Item> myItems;

            // validate the user, return the correct Items
            if (isHavingPromoCode)
            {
                myItems = premiumCustomer.ViewMyShoppingCard();
            }
            else
            {
                myItems = customer.ViewMyShoppingCard();
            }

            Catalog.PrintItems(myItems);

            // choosing an Item index
            StandardMessages.ChosingByIndex();
            int index = int.Parse(Console.ReadLine());

            if (isHavingPromoCode)
            {
                // index - 1, because the program displays the indexes incremented by 1, and the array start from zero position
                premiumCustomer.ShoppingCard.Items.RemoveAt(index - 1);
            }
            else
            {
                // index - 1, because the program displays the indexes incremented by 1, and the array start from zero position
                customer.ShoppingCard.Items.RemoveAt(index - 1);
            }

            StandardMessages.Successfully("remove");
        }
        static decimal TotalCost(bool isHavingPromoCode, Customer customer, PremiumCustomer premiumCustomer)
        {
            decimal totalCost;
            if (isHavingPromoCode)
            {
                //when the customer is premium the method accepts discount
                totalCost = Checkout.CalculateTotalCost(premiumCustomer.ShoppingCard.Items, premiumCustomer.DiscountPercentage);
            }
            else
            {
                totalCost = Checkout.CalculateTotalCost(customer.ShoppingCard.Items);
            }
            return totalCost;
        }
    }
}
