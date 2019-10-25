using System;
using System.Collections.Generic;
using System.Text;

namespace gzhao_checkout_total
{
    /// <summary>
    /// This class stores a list of products.
    /// </summary>
    public class Database_API
    {

        private List<Item> items;

        public Database_API()
        {
            items = new List<Item>();
        }

        /// <summary>
        /// Adds the input item into the currently existing list if an item
        /// with the exact same name does not exist.
        /// </summary>
        /// <param name="item"></param>
        public void AddToList(Item item)
        {
            bool duplicateExists = false;

            int i = 0;
            while (!duplicateExists && items.Count > 0)
            {
                duplicateExists = item.Match(items[i]);
                i++;
            }
            if (!duplicateExists)
            {
                items.Add(item);
            }
        }

        /// <summary>
        /// Removes items of the exact same name from the list.
        /// </summary>
        /// <param name="itemName"></param>
        public void RemoveFromList(string itemName)
        {
            int i = items.Count-1;
            while(i >= 0)
            {
                if (items[i].Match(itemName));
                {
                    items.RemoveAt(i);
                }
                i--;
            }
        }

        /// <summary>
        /// Returns the size of the item roster.
        /// </summary>
        /// <returns></returns>
        public int ItemListCount()
        {
            return items.Count;
        }
    }
}
