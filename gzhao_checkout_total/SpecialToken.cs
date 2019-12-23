using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    public class SpecialToken
    {
        /// <summary>
        /// The Special that this token represents.
        /// </summary>
        public Special special { get; private set; }

        /// <summary>
        /// The total amount of items this Special gets to affect.
        /// </summary>
        public int affectCount { get; private set; }

        /// <summary>
        /// Create a new special token that represents the given special.
        /// </summary>
        /// <param name="sp">The Special that is being represented.</param>
        /// <param name="items">The total amount of items this special is representing.</param>
        public SpecialToken(Special sp, int items)
        {
            special = sp;
            BuildCount(items);
        }

        /// <summary>
        /// builds the total amount of items this Special should affect.
        /// </summary>
        /// <param name="items"></param>
        private void BuildCount(int items)
        {
            //How many items we have to deal with.
            int cap = items;
            //How many items we get to give the special to.
            //Doing it this way to account for multiple "3 for 5" deals.
            int applied = 0;
            
            while (cap > 0)
            {
                //Reduce the cap to remove one set from consideration.
                cap -= special.activationRequirement;

                if (cap >= 0)
                {
                    //If we removed a set and have enough left over
                    //then we have enough to apply this special.
                    applied += special.appliedToAmount;
                }
            }

            affectCount = applied;
        }

        /// <summary>
        /// Same Match operator as the Special variable this Token manages.
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public bool Match(string itemType)
        {
            return special.Match(itemType);
        }

        /// <summary>
        /// returns the affected item of the special of this Token.
        /// </summary>
        /// <returns></returns>
        public string GetAffected()
        {
            return special.itemAffected;
        }
    }
}
