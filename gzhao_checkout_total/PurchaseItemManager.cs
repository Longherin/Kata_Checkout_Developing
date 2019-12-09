using System.Collections.Generic;

namespace Gzhao_checkout_total
{
    public class PurchaseItemManager
    {
        /// <summary>
        /// The receipt. Each item on the receipt represents one purchase of some kind.
        /// </summary>
        private List<ItemInCart> itemRosterAsPurchased;
        /// <summary>
        /// Each item on the specials roster represents one special that the buyer
        /// qualifies for.
        /// </summary>
        private List<Special> appliedSpecials;

        private SpecialManager spManager;
        
        public PurchaseItemManager()
        {
            itemRosterAsPurchased = new List<ItemInCart>();
            spManager = new SpecialManager();
        }

        /// <summary>
        /// Adds an item into the cart of the given number (of items).
        /// </summary>
        /// <param name="itemName">The item being purchased.</param>
        /// <param name="itemNumber">How many is being purchased.</param>
        public void Add(string itemName, float itemNumber)
        { 
            itemRosterAsPurchased.Add(new ItemInCart(Database_API.GetItem(itemName), itemNumber));
            Tally();
        }

        /// <summary>
        /// Remove the last item in the item Roster.
        /// </summary>
        public void RemoveLast()
        {
            itemRosterAsPurchased.RemoveAt(itemRosterAsPurchased.Count - 1);
            Tally();
        }

        /// <summary>
        /// Removes the most recent entry with the matching name from the item roster.
        /// </summary>
        /// <param name="itemName"></param>
        public void RemoveSpecific(string itemName)
        {
            int i = itemRosterAsPurchased.Count;
            while(i > 0)
            {
                i--;

                bool match = itemRosterAsPurchased[i].Match(itemName);

                if(match)
                {
                    itemRosterAsPurchased.RemoveAt(i);
                    break;
                }
            }
            Tally();
        }

        /// <summary>
        /// The amount of items (in entries) that have been purchased.
        /// </summary>
        /// <returns></returns>
        public int TotalPurchasedEntries()
        {
            return itemRosterAsPurchased.Count;
        }

        /// <summary>
        /// The total cost of this purchase.
        /// </summary>
        /// <returns></returns>
        public float TotalPurchase()
        {
            float total = 0;
            foreach(ItemInCart item in itemRosterAsPurchased)
            {
                total += item.GetPrice();
            }

            return total;
        }

        /// <summary>
        /// Updates the tallied item's costs with respect to what specials they have applied.
        /// </summary>
        private void Tally()
        {
            SpecialManager.ReadAndApply(itemRosterAsPurchased);
        }
    }
}
