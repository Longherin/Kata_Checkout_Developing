using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    /// <summary>
    /// This class lets us interface with the 'database'.
    /// </summary>
    public class Database_API
    {
        /// <summary>
        /// Adds an item to the list of items.
        /// </summary>
        /// <param name="name">Name of the item.</param>
        /// <param name="cost">Cost of the item.</param>
        /// <param name="sellByWeight">If true, the item price is dependent on its weight.</param>
        public static void AddItem(string name, float cost, bool sellByWeight=false)
        {
            Item newItem = new Item(name, cost, sellByWeight);
            Database.AddItem(newItem);
        }

        /// <summary>
        /// Removes all item entries of the same name from the list of items.
        /// </summary>
        /// <param name="name"></param>
        public static void Remove(string name)
        {
            Database.RemoveItem(name);
        }

        /// <summary>
        /// Gets the item that matches the given search parameter
        /// (in our case, the name of the item).
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Item GetItem(string name)
        {
            return Database.GetItem(name);
        }

        /// <summary>
        /// Returns the price of an item given its name.
        /// Will return 0 if the name is not in the list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static float GetCost(string name)
        {
            return Database.GetCost(name);
        }

        /// <summary>
        /// Gets the count of how many items are in the database.
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            return Database.GetItemCount();
        }

        /// <summary>
        /// Purges the item list. Use for testing only.
        /// </summary>
        public static void Clean()
        {
            Database.PurgeItems();
        }
    }
}
