using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    class PurchaseItemManager
    {
        private List<TalliedItem> itemRoster;
        
        public PurchaseItemManager()
        {
            itemRoster = new List<TalliedItem>();
        }

        /// <summary>
        /// Add a new entry in the item roster with the given parameters.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemNumber"></param>
        public void Add(string itemName, float itemNumber)
        {
            itemRoster.Add(new TalliedItem(itemName, itemNumber));
        }

        /// <summary>
        /// Remove the last item in the item Roster.
        /// </summary>
        public void RemoveLast()
        {
            itemRoster.RemoveAt(itemRoster.Count - 1);
        }

        /// <summary>
        /// Removes the most recent entry with the matching name from the item roster.
        /// </summary>
        /// <param name="itemName"></param>
        public void RemoveSpecific(string itemName)
        {
            int i = itemRoster.Count;
            while(i > 0)
            {
                i--;

                bool match = itemRoster[i].Match(itemName);

                if(match)
                {
                    itemRoster.RemoveAt(i);
                    break;
                }
            }
        }

        public int Total()
        {
            return itemRoster.Count;
        }
    }
}
