using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    public class Checkout
    {

        public static void Main(String[] args)
        {
            Database_Builder.BuildData();

            PurchaseItemManager pim = new PurchaseItemManager();
            //            List<ItemInCart> pim = new List<ItemInCart>();

            //            pim.Add(new ItemInCart(Database_API.GetItem("Chicken"), 10));
            //            pim.Add(new ItemInCart(Database_API.GetItem("Chicken"), 5));

            pim.Add("chicken", 10);
            pim.Add("soup");
            pim.Add("chiCken", 5);
            pim.Add("soup");
            pim.Add("cHicken", 5);
            pim.Add("soup");

            //            float total = 0;
            //            foreach (ItemInCart item in pim)
            //            {
            //                Console.WriteLine("this item is " + item.GetPrice());
            //                total += item.GetPrice();
            //            }

            Console.Write(pim.TotalPurchase());

            Console.ReadKey();
        }

        private static void BuildItems()
        {
            //Items that sell by weight
            Database_API.AddItem("Beef", 10, true);
            Database_API.AddItem("Chicken", 10, true);
            Database_API.AddItem("Peas", 2, true);

            //Items that sell by unit
            Database_API.AddItem("Soup", 5);
            Database_API.AddItem("Pencils", 6);
            Database_API.AddItem("Carpet", 100);
        }

        private static void BuildSpecials()
        {
            Database_API.AddSpecial(new Special("Soup", 0, 2, 3, 3));
            Database_API.AddSpecial(new Special("Chicken", 1, 50, 2, 1));
        }
    }
}
