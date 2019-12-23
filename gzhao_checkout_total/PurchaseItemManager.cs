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
        private List<SpecialToken> appliedSpecials;

        private Dictionary<string, int> itemRosterTally;
        
        public PurchaseItemManager()
        {
            itemRosterAsPurchased = new List<ItemInCart>();
            appliedSpecials = new List<SpecialToken>();
            itemRosterTally = new Dictionary<string, int>();
        }

        /// <summary>
        /// Adds an item into the cart of the given number (of items).
        /// </summary>
        /// <param name="itemName">The item being purchased.</param>
        /// <param name="itemNumber">How many is being purchased.</param>
        public void Add(string itemName, float itemNumber=1)
        {
            ItemInCart newItem = new ItemInCart(Database_API.GetItem(itemName), itemNumber);
            string itemNameClean = newItem.GetName();
            itemRosterAsPurchased.Add(newItem);

            if (itemRosterTally.ContainsKey(itemNameClean))
            {
                itemRosterTally[itemNameClean]++;
            }
            else
            {
                itemRosterTally.Add(itemNameClean, 1);
            }

            Tally();
        }

        /// <summary>
        /// Remove the last item in the item Roster.
        /// </summary>
        public void RemoveLast()
        {
            string name = itemRosterAsPurchased[itemRosterAsPurchased.Count - 1].GetName();
            itemRosterAsPurchased.RemoveAt(itemRosterAsPurchased.Count - 1);

            itemRosterTally[name]--;

            Tally();
        }

        /// <summary>
        /// Removes the most recent entry with the matching name from the item roster.
        /// </summary>
        /// <param name="itemName"></param>
        public void RemoveSpecific(string itemName)
        {
            int i = itemRosterAsPurchased.Count;
            string name = "";

            while(i > 0)
            {
                i--;

                bool match = itemRosterAsPurchased[i].Match(itemName);

                if(match)
                {
                    name = itemRosterAsPurchased[i].GetName();

                    itemRosterAsPurchased.RemoveAt(i);
                    
                    break;
                }
            }

            itemRosterTally[name]--;

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
        /// The total cost of this purchase without any specials attached.
        /// </summary>
        /// <returns></returns>
        public float TotalNoSpecialPurchase()
        {
            float total = 0;
            foreach(ItemInCart item in itemRosterAsPurchased)
            {
                total += item.GetOriginalPrice();
            }

            return total;
        }

        /// <summary>
        /// Get the name of a product at the current pointer.
        /// </summary>
        /// <param name="pointer"></param>
        /// <returns></returns>
        public ItemInCart GetAtPosition(int pointer)
        {
            return itemRosterAsPurchased[pointer];
            
        }

        /// <summary>
        /// Updates the tallied item's costs with respect to what specials they have applied.
        /// </summary>
        private void Tally()
        {
            PurgeSpecials();
            appliedSpecials = SpecialManager.ReadAndApply(itemRosterTally);
            SpecialManager.ReadAndApplyDeals(appliedSpecials, itemRosterAsPurchased);
        }

        /// <summary>
        /// Clean the special tag from all currently purchased items.
        /// </summary>
        private void PurgeSpecials()
        {
            foreach(ItemInCart item in itemRosterAsPurchased)
            {
                item.ClearSpecial();
            }
        }
    }
}
