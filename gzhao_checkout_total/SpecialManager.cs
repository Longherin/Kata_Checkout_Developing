using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    class SpecialManager
    {
        
        /// <summary>
        /// Reads the list of purchases and applies any applicable specials that
        /// are discovered. The specials applied are returned.
        /// </summary>
        /// <param name="purchases">The applied specials.</param>
        /// <returns></returns>
        public static Dictionary<int, Special> ReadAndApply(List<ItemInCart> purchases)
        {
            List<ItemInCart> t_purchases = purchases;
            Dictionary<int, Special> appliedDeals = new Dictionary<int, Special>();

            if (purchases.Count > 1)
            {
                t_purchases = SortByCost(purchases);
            }
            //Note that this only considers entries.
            //Unless there's some weird thing where 7.03 pounds of beef can get
            //discounts on 5 pounds of it.
            Dictionary<string, int> talliedItems = new Dictionary<string, int>();

            //Tally the total items of our purchase.
            int i = 0;
            while(i < t_purchases.Count)
            {
                if (talliedItems.ContainsKey(t_purchases[i].GetName()))
                {
                    talliedItems[t_purchases[i].GetName()] += 1;
                }
                else
                {
                    talliedItems.Add(t_purchases[i].GetName(), 1);
                }
                //Check to see if our purchases qualify for specials
                foreach (KeyValuePair<string, int> spItem in talliedItems)
                {
                    if (Specials_API.TryGetMatchingDeal(spItem.Key, spItem.Value))
                    {
                        Special special = Specials_API.GetMatchingDeal(spItem.Key, spItem.Value);

                        appliedDeals.Add(i, special);
                    }
                }
                i++;
            }
            
            ApplySpecials(appliedDeals, t_purchases);
            
            return appliedDeals;
        }

        /// <summary>
        /// Actually applies the deals as given into the list of purchases.
        /// </summary>
        /// <param name="appliedDeals"></param>
        /// <param name="purchases"></param>
        private static void ApplySpecials(Dictionary<int, Special> appliedDeals, List<ItemInCart> purchases)
        {
            foreach(KeyValuePair<int, Special> special in appliedDeals)
            {
                int applied = special.Value.appliedToAmount;
                int pointer = special.Key;

                //Go UP the list and apply specials when the name matches.
                while(applied > 0)
                {
                    int i = 0;
                    if (purchases[pointer - i].Match(special.Value.itemAffected))
                    {
                        purchases[pointer - i].AffectedBySpecial(special.Value);

                        applied--;
                    }
                    i++;
                }
            }
        }
        
        /// <summary>
        /// Rearrange the purchase list from cheapest to most expensive for the
        /// purposes of applying specials.
        /// </summary>
        /// <param name="purchases"></param>
        /// <returns></returns>
        private static List<ItemInCart> SortByCost(List<ItemInCart> purchases) 
        {
            List<ItemInCart> newList = new List<ItemInCart>();
            
            int i = 0;
            while (i < newList.Count-1)
            {
                ItemInCart next = purchases[i];

                int j = newList.Count;
                bool capped = false;
                while(!capped && j > 0)
                {
                    if (newList[j - 1].GetPrice() < next.GetPrice())
                    {
                        //As of this step, the next item in the list
                        //has a lower price, so we can't be smaller than that.
                        capped = true;
                    }
                    else
                    {
                        j--;
                    }
                    
                }

                newList.Insert(j, next);
                i++;
            }

            return newList;
        }
    }
}
