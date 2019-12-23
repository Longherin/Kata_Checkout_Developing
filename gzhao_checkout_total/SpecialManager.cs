using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    public class SpecialManager
    {
        
        /// <summary>
        /// Reads the list of purchases and applies any applicable specials that
        /// are discovered. The specials applied are returned.
        /// </summary>
        /// <param name="purchases">The applied specials.</param>
        /// <returns></returns>
        public static List<SpecialToken> ReadAndApply(Dictionary<string, int> talliedItems)
        {
            SpecialTokenManager appliedDeals = new SpecialTokenManager();
            
            //Check to see if the quantity of our purchases qualify for specials.
            foreach (KeyValuePair<string, int> spItem in talliedItems)
            {
                int check = spItem.Value;       //This is the item count.
                int specialLimit = -1;          //This is the amt of items needed for a special to fire.
                                                //At -1, it is a dummy flag.
                bool allClear = false;          //When true, we've done all the checks possible.
                while (!allClear)
                {
                    //In event of needing a special to trigger multiple times.
                    if (Database_API.TryGetMatchingDeal(spItem.Key, check))
                    {
                        Special special = Database_API.GetMatchingDeal(spItem.Key, check);
                        appliedDeals.Add(special, special.activationRequirement);

                        specialLimit = special.activationRequirement;

                    }
                    if (specialLimit != -1 && check >= specialLimit)
                    {
                        //If we have enough to activate the special again, continue loop.
                        check -= specialLimit;
                    }
                    else
                    {
                        //Break from loop.
                        allClear = true;
                    }
                }
            }
            
            return appliedDeals.GetTokensAsList();
        }

        /// <summary>
        /// Actually applies the deals as given into the list of purchases.
        /// </summary>
        /// <param name="appliedDeals"></param>
        /// <param name="purchases"></param>
        public static void ReadAndApplyDeals(List<SpecialToken> inputList, List<ItemInCart> purchases)
        {
            //currently, we have: a list of purchases, and a list of specials.
            //We need: a list of the most expensive items we've purchased.
            //The size of the list is the same as the amount of items we have to cover.
            SpecialTokenManager appliedDeals = new SpecialTokenManager(inputList);

            Stack<ItemInCart> t_list = new Stack<ItemInCart>();
            int i = 0;
            while (i < appliedDeals.GetTokenListSize())
            {
                //Iterate through the Specials.
                foreach (ItemInCart item in purchases)
                {
                    //Iterate through the purchases.
                    if (item.Match(appliedDeals.GetTokenAt(i).GetAffected()))
                    {
                        //If we have an item that matches, toss it into the list.
                        t_list = AddLargest(item, t_list);
                    }
                }
                
                ApplySpecials(t_list, appliedDeals.GetTokenAt(i));
                i++;
            }
             
        }

        /// <summary>
        /// Creates a stack of the hardcap size. The priciest items belonging to the given
        /// stack are placed into the returning stack.
        /// </summary>
        /// <param name="item">The item being compared.</param>
        /// <param name="stack">The stack of special items we're adding into. Highest price is added first.</param>
        private static Stack<ItemInCart> AddLargest(ItemInCart item, Stack<ItemInCart> stack)
        {
            Queue<ItemInCart> q = new Queue<ItemInCart>();
            int i = stack.Count;

            while(stack.Count > 0)
            {
                q.Enqueue(stack.Pop());
            }
            
            ItemInCart smallest = item;
            while (i > 0)
            {
                //The iterating item.
                ItemInCart thing = q.Dequeue();

                if(thing.GetPrice() < smallest.GetPrice())
                {
                    //If the current item is smaller than the comparator, pop it back into the list.
                    q.Enqueue(thing);
                }
                else
                {
                    //If the newcomer is smaller, add it into the list.
                    //The dequeued item is now the 'next smallest' item.
                    q.Enqueue(smallest);
                    smallest = thing;
                }
                i--;
            }

            q.Enqueue(smallest);
            Stack<ItemInCart> ret = new Stack<ItemInCart>();
             
            while(q.Count > 0)
            {
                ret.Push(q.Dequeue());
            }

            return ret;
        }
        
        /// <summary>
        /// Actually apply the specials to the items in the cart.
        /// Items that already have specials are not counted.
        /// </summary>
        /// <param name="inCart"></param>
        /// <param name="special"></param>
        private static void ApplySpecials(Stack<ItemInCart> inCart, SpecialToken special)
        {
            int i = special.affectCount;
            while(i > 0 && inCart.Count > 0)
            {
                ItemInCart item = inCart.Pop();
                if (item.SetSpecialValue(special.special))
                {
                    i--;
                }
            }
        }

        
    }
}
