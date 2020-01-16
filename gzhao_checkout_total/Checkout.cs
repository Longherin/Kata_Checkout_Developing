using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    public class Checkout
    {

        private const int SPACING_NAME = 30;
        private const int SPACING_VALUE = 10;

        public static void Main(String[] args)
        {
            Database_Builder.BuildData();

            PurchaseItemManager pim = new PurchaseItemManager();
            
            WriteShopHeader();
            WriteProducts();
            WriteSpecials();
            WritePromptHelp();
            WritePrompt();

            pim.Add("flour");
            pim.Add("flour");
            pim.Add("flour");

            Console.Write(pim.TotalPurchase());

            Console.ReadKey();
        }

        private static void WriteShopHeader()
        {
            Console.WriteLine("Hello and welcome to the ShopEasy Online Order Service!");
        }

        private static void WriteProducts()
        {
            Console.WriteLine("We have the following selection:");
            Console.WriteLine("Name");
            Console.WriteLine(WriteItems());
        }

        private static void WritePromptHelp()
        {

        }

        private static void WritePrompt()
        {

        }
        
        /// <summary>
        /// Writes a list of all items available in the database.
        /// </summary>
        /// <returns>A string of all items in the database.</returns>
        private static string WriteItems()
        {
            StringBuilder builder = new StringBuilder();

            int h = 0;
            int i = Database_API.GetItemCount();

            while (h < i)
            {
                Item item = Database_API.GetItem(h);
                builder.Append(Format(item.name, SPACING_NAME));
                builder.Append(Format(item.price.ToString(), SPACING_VALUE));
                builder.AppendLine(FormatMark(item.priceByWeight));
                h++;
            }
            return builder.ToString();
        }

        /// <summary>
        /// Writes a list of all specials available in the database.
        /// </summary>
        /// <returns></returns>
        private static string WriteSpecials()
        {
            StringBuilder builder = new StringBuilder();

            int h = 0;
            int i = Database_API.GetSpecialsCount();

            while (h < i)
            {
                Special item = Database_API.GetSpecial(h);
                builder.Append(Format(item.itemAffected, SPACING_NAME));
                builder.AppendLine(FormatSP(item, SPACING_NAME));
                h++;
            }
            return builder.ToString();
        }

        /// <summary>
        /// Takes an input string, a series of blank spaces, and formats it nice and pretty.
        /// Note: will not be pretty if the input is longer than the spacing given.
        /// </summary>
        /// <param name="input"></param>
        private static string Format(string input, int blanks)
        {
            StringBuilder formatter = new StringBuilder();

            int startPoint = input.Length;

            while(startPoint < blanks)
            {
                formatter.Append(" ");
                startPoint++;
            }

            return formatter.ToString();
        }

        /// <summary>
        /// Takes a Special as an input and returns its attribute
        /// in a readable format.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="blanks"></param>
        /// <returns></returns>
        private static string FormatSP(Special input, int blanks)
        {
            StringBuilder formatter = new StringBuilder();
            bool percentage = input.discount_type == Special.DISCOUNT_TYPE.REDUCE_BY_PERCENTAGE;
            //Same amount of products are affected by the discount.
            if (input.itemsNeededToFire == input.itemsApplied)
            {
                formatter.Append(input.itemsApplied.ToString());
                if (percentage)
                {

                }
                formatter.Append(" for $");
                formatter.Append(input.itemCostChange.ToString());
            }
            //Need more products than the affected count.
            else
            {
                formatter.Append("Buy ");
                formatter.Append(input.itemsNeededToFire.ToString());
                formatter.Append(" Get ");
                formatter.Append(input.itemsApplied.ToString());
            }
            
            return formatter.ToString();
        }

        /// <summary>
        /// Returns a marker if the given boolean happens to be true.
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        private static string FormatMark(bool flag)
        {
            string marker = " ";

            if (flag)
            {
                marker = "*";
            }

            return marker;
        }
    }
}
