using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    public class ItemInCart
    {
        /// <summary>
        /// The item that's being purchased.
        /// </summary>
        private Item itemRef;

        /// <summary>
        /// the amount of this item that is being purchased.
        /// Really only useful for item by weight.
        /// </summary>
        public float quantity { get; private set; }

        /// <summary>
        /// If true, this item's price has been discounted.
        /// </summary>
        public bool isDiscounted { get; private set; }
        /// <summary>
        /// When true, the affected item is affected by a percentage change to its price.
        /// </summary>
        private bool isPercentage;
        /// <summary>
        /// The amount that this purchase is being changed by.
        /// </summary>
        private float changeAmount;

        public ItemInCart(Item item, float amt = 1)
        {
            itemRef = item;
            quantity = amt;
        }
        
        /// <summary>
        /// Changes this item's price based on the special as given.
        /// </summary>
        /// <param name="special"></param>
        public bool SetSpecialValue(Special special)
        {
            bool flagSet = false;
            if (!isDiscounted)
            {
                isDiscounted = true;
                isPercentage = special.GetIsPercentage();
                changeAmount = special.costChange;
                flagSet = true;
            }

            return flagSet;
        }

        /// <summary>
        /// Removes this item's special marker.
        /// </summary>
        public void ClearSpecial()
        {
            isDiscounted = false;
            isPercentage = false;
        }

        /// <summary>
        /// Returns the name of the item being purchased.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return itemRef.name;
        }

        /// <summary>
        /// Returns true if the target string matches the name of the item referenced.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Match(string target)
        {
            string nn = GetName().ToLower().Trim();

            return nn.Equals(target.ToLower().Trim());
        }

        /// <summary>
        /// Gets the price of the purchase.
        /// </summary>
        /// <returns></returns>
        public float GetPrice()
        {
            float total = itemRef.price;
            if (itemRef.priceByWeight)
            {
                total *= quantity;
            }

            if (isDiscounted)
            {
                if (!isPercentage)
                {
                    total = changeAmount;
                }
                else
                {
                    total *= (100 - changeAmount) * 0.01f;
                }
            }
            return total;
        }

        public float GetOriginalPrice()
        {
            float total = itemRef.price;
            if (itemRef.priceByWeight)
            {
                total *= quantity;
            }

            return total;
        }
    }
}
