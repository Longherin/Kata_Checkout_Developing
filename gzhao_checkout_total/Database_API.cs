using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    /// <summary>
    /// This class stores a list of products.
    /// </summary>
    public class Database_API
    {

        private PurchaseItemManager itemManager;

        public Database_API()
        {
            itemManager = new PurchaseItemManager();
        }
        
        /// <summary>
        /// Adds an item to the item manager. The amount is either the unit count
        /// or else the weight of the item.
        /// </summary>
        /// <param name="item">The name of the input item.</param>
        /// <param name="amount">The unit count of the item (if not assessed by weight)
        /// or the weight of the item.</param>
        public void AddToList(string item, float amount)
        {
            itemManager.Add(item, amount);
        }

        /// <summary>
        /// Removes the most currrent item on the receipt with the given name.
        /// </summary>
        /// <param name="itemName"></param>
        public void RemoveLast()
        {
            itemManager.RemoveLast();
        }

        /// <summary>
        /// Removes the most current specific item on the receipt with the given name.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveSpecific(string item)
        {
            itemManager.RemoveSpecific(item);
        }

        /// <summary>
        /// Returns the size of the item roster.
        /// </summary>
        /// <returns></returns>
        public int ItemListCount()
        {
            return itemManager.Total();
        }
    }
}
