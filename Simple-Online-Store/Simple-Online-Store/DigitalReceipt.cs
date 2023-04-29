using Online_Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Simple_Online_Store
{
    class DigitalReceipt
    {
        public DigitalReceipt(Customer customer, PremiumCustomer premiumCustomer, bool isHavingPromoCode)
        {
            Customer = customer;
            PremiumCustomer = premiumCustomer;
            IsHavingPromoCode = isHavingPromoCode;
        }

        public static bool IsHavingPromoCode { get; set; }
        public static Customer Customer { get; set; }
        public static PremiumCustomer PremiumCustomer { get; set; }

        public void Operation()
        {
            //read the original receipt txt file
            string receipt = Reading();

            //custom receipt
            Writing(receipt);

        }
        static string Reading()
        {
            StreamReader receiptReader = new StreamReader(@"..\..\..\DigitalReceipts\originalReceipt.txt");

            using (receiptReader)
            {
                return receiptReader.ReadToEnd();
            }
        }
        static void Writing(string receipt)
        {
            StreamWriter receiptWriter = new StreamWriter(@"..\..\..\DigitalReceipts\receipt.txt");

            StringBuilder fullReceipt = new StringBuilder(receipt);

            //wrutung the current date
            string formattedDateTime = DateTime.Now.ToString("h:mm:ss tt");
            fullReceipt.Replace("{date}", formattedDateTime);

            List<Item> items = new List<Item>();
            StringBuilder itemsBuilder = new StringBuilder(receipt);
            decimal totalCost = 0;
            if (IsHavingPromoCode)
            {
                items = PremiumCustomer.ViewMyShoppingCard();
                itemsBuilder = ShoppingCard.ReceiptAppend(items);
                totalCost = PremiumCustomer.CostOfShoppingCard();
            }
            else
            {
                items = Customer.ViewMyShoppingCard();
                itemsBuilder = ShoppingCard.ReceiptAppend(items);
                totalCost = Customer.CostOfShoppingCard();
            }

            fullReceipt.Replace("{products}", itemsBuilder.ToString());
            fullReceipt.Replace("{totalSum}", totalCost.ToString());

            using (receiptWriter)
            {
                receiptWriter.WriteLine(fullReceipt.ToString());
            }

        }
    }
}
