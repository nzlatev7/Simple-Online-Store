using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store
{
    class Program
    {
        static void Main(string[] args)
        {

            Catalog catalog = new Catalog();
            var items = catalog.Items;

            //create a customer
            Customer customer = new Customer("Nasko", 12, 200);

            //create a premium customer, the main change here is the discount percent
            PremiumCustomer premiumCustomer = new PremiumCustomer("Pesho", 22, 12000, 10);

            //print the catalog of items
            catalog.PrintItems(items);

            string command;
            while ((command = Console.ReadLine()) != "end with shopping")
            {

                //add item
                if (command == "add item")
                {
                    Console.Write("Choose one of these items! Give an index: ");
                    int index = int.Parse(Console.ReadLine());

                    //add item
                    Item currentItemForAdding = items[index];
                    ShoppingCard shoppingCard = new ShoppingCard();
                    customer.ShoppingCard.Items.Add(currentItemForAdding);

                    //delete the item
                    items.Remove(index);

                    //print the catalog of items
                    catalog.PrintItems(items);
                }

                //every customer can view their shopping card
                else if (command == "view my shopping card")
                {
                    List<Item> myItems = customer.ViewMyShoppingCard();

                    // Here PrintItems is a method with the same name but print the List<Item>
                    // method overloading -> same name with different parameters
                    catalog.PrintItems(myItems);
                }

                //every customer can view their total cost of items in it
                else if (command == "cost")
                {
                    decimal cost = customer.CostOfShoppingCard();
                    Console.WriteLine(cost);
                }

                //search for items by name
                else if (command == "search")
                {
                    string item = Console.ReadLine();

                    //check if the dictionary have items with name like item
                    List<Item> sameItems = items.Select(x => x.Value).Where(x => x.Name == item).ToList();

                    if (sameItems == null)
                    {
                        Console.WriteLine("Item not found");
                        continue;
                    }

                    //printing the duplicates
                    foreach (var currentItem in sameItems)
                    {
                        Console.WriteLine($"{currentItem.Name}, {currentItem.Description}, {currentItem.Price}");
                    }
                }
            }

            //when we end with shopping, the items go through a checkout process
            Checkout checkout = new Checkout();
            decimal totalCost = checkout.CalculateTotalCost(customer.ShoppingCard.Items);

            if (totalCost <= customer.Money)
            {
                Console.WriteLine("Successful, have a nice day!");
            }
            else
            {
                Console.WriteLine("Don't have enough money!");
            }
        }
    }
}
