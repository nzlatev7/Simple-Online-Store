using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Online_Store
{
    public class StandardMessages
    {
        public static void PromoCode()
        {
            Console.Write("Type promo code if you have: ");
        }
        public static void TypeCommand()
        {
            Console.Write("Type command: ");
        }
        public static void ChosingByIndex()
        {
            Console.Write("Choose one of these items! Give an index: ");
        }
        public static void EmptyShoppingCard()
        {
            Console.WriteLine("Your shopping card is empty!");
        }
        public static void DisplayCost(decimal cost)
        {
            Console.WriteLine($"Your cost: ${cost}");
        }
        public static void ItemNotFound()
        {
            Console.WriteLine("Item not found");
        }
        public static void TotalCost(decimal totalCost)
        {
            Console.WriteLine($"Your total cost is {totalCost}");
        }
        public static void EndSuccessful()
        {
            Console.WriteLine("Successful, have a nice day!");
        }
        public static void DoNotHaveEnoughMoney()
        {
            Console.WriteLine("Don't have enough money!");
        }
        public static void Successfully(string operation)
        {
            Console.WriteLine($"Successfully {operation}ed");
        }
        public static void InvalidCommand()
        {
            Console.WriteLine($"Invalid Command");
        }
    }
}
