using System;
using System.Collections.Generic;
using System.Text;

namespace gzhao_checkout_total
{
    public class Item
    {
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// Full price of the item.
        /// </summary>
        public float price { get; private set; }
        
        /// <summary>
        /// When true, the item's price is determined by it's weight.
        /// The price of the item is referenced to one pound.
        /// </summary>
        public bool priceByWeight { get; private set; }
        
        /// <summary>
        /// Create a new item.
        /// </summary>
        /// <param name="newName">Name of the item.</param>
        /// <param name="newPrice">Price of the item.</param>
        /// <param name="notSingleType">If true, the item is sold as single items. when false, item price is per pound. Defaults to false.</param>
        public Item(string newName, float newPrice, bool sellByWeight=false)
        {
            name = newName.Trim();
            price = newPrice;
            priceByWeight = sellByWeight;
        }

        /// <summary>
        /// Checks to see if the input item has the same name as this item.
        /// Returns true if the two names match.
        /// </summary>
        /// <param name="matchTarget">The input item.</param>
        /// <returns>True if both names match</returns>
        public bool Match(Item matchTarget)
        {
            string mtName = matchTarget.name.ToLower();
            string tpName = name.ToLower();
            return mtName.Equals(tpName);
        }
    }
}
