using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    public class Database_Builder
    {
        private static bool builtItems = false;
        private static bool builtSpecials = false;

        public static void BuildData()
        {
            if (!builtItems)
            {
                //Items that sell by weight
                Database_API.AddItem("Beef", 10, true);
                Database_API.AddItem("Chicken", 10, true);
                Database_API.AddItem("Peas", 10, true);

                //Items that sell by unit
                Database_API.AddItem("Soup", 5);
                Database_API.AddItem("Pencils", 6);
                Database_API.AddItem("Carpet", 100);
                Database_API.AddItem("Candy", 4);

                //Items that sell by weight but we actually care about it.
                Database_API.AddItem("Flour", 6, true);

                builtItems = true;
            }

            if (!builtSpecials)
            {
                Database_API.AddSpecial(new Special("Soup", 0, 2, 3, 3));
                Database_API.AddSpecial(new Special("Candy", 0, 2, 2, 2));
                Database_API.AddSpecial(new Special("Flour", 1, 50, 1, 1));
                Database_API.AddSpecial(new Special("Chicken", 1, 50, 2, 1));

                builtSpecials = true;
            }
        }
    }
}
