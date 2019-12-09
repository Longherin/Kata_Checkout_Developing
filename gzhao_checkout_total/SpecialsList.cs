using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    class Specials_API
    {
        private static List<Special> listOfSpecials = new List<Special>();
        
        /// <summary>
        /// Adds a special into the list of Specials.
        /// </summary>
        /// <param name="special">The special being added.</param>
        public void AddSpecial(Special special)
        {
            listOfSpecials.Add(special);
        }

        /// <summary>
        /// Removes ALL Specials in the list that affects this item.
        /// </summary>
        /// <param name="name">The item being afected.</param>
        public void RemoveSpecial(string name)
        {
            int i = listOfSpecials.Count;
            while(i > 0)
            {
                i--;
                if (listOfSpecials[i].Match(name))
                {
                    listOfSpecials.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Returns true if there is a deal that can be applied with the given
        /// purchases.
        /// </summary>
        /// <param name="talliedItems"></param>
        /// <returns></returns>
        internal static bool TryGetMatchingDeal(string name, int amount)
        {
            bool hasDeal = false;
            
            foreach(Special item in listOfSpecials)
            {
                if (item.itemAffected.Equals(name) && item.activationRequirement == amount)
                {
                    hasDeal = true;
                    break;
                }
            }

            return hasDeal;
        }

        /// <summary>
        /// Returns the deal that can be applied with the given purchases,
        /// else it returns a null object.
        /// </summary>
        /// <param name="talliedItems"></param>
        /// <returns></returns>
        internal static Special GetMatchingDeal(string name, int amount)
        {
            Special special = new Special();
            foreach(Special item in listOfSpecials)
            {
                if(item.itemAffected.Equals(name) && item.activationRequirement == amount)
                {
                    special = item;
                    break;
                }
            }

            return special;
        }
    }
}
