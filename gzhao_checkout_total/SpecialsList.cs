using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    class SpecialsList
    {
        private static List<Special> listOfSpecials = new List<Special>();

        /// <summary>
        /// Adds a special into the list of specials. No duplicate deals are allowed.
        /// Honestly would work a lot better with a code rather than a string match but
        /// apparently that's what I'm working with today.
        /// </summary>
        /// <param name="input">The deal being added.</param>
        public static void addSpecial(Special input)
        {
            bool hasDuplicate = false;
            int i = 0;
            while(!hasDuplicate && i < listOfSpecials.Count)
            {
                if (listOfSpecials[i].description.Equals(input.description))
                {
                    hasDuplicate = true;
                }
                i++;
            }

            if (!hasDuplicate)
            {
                listOfSpecials.Add(input);
            }
        }

        /// <summary>
        /// Removes a specific special from the list of specials.
        /// Uses name matching.
        /// </summary>
        /// <param name="input"></param>
        public static void removeSpecial(Special input)
        {
            int i = listOfSpecials.Count;
            bool removed = false;
            while (i >= 0 && !removed)
            {
                if (listOfSpecials[i].description.Equals(input.description))
                {
                    listOfSpecials.RemoveAt(i);
                }
                i--;
            }
        }

        /// <summary>
        /// removes the oldest special that involves the item involved.
        /// </summary>
        /// <param name="input">the name of the item involved.</param>
        public static void removeSpecial(string input)
        {
            int i = 0;
            bool removed = false;
            while(i < listOfSpecials.Count && !removed)
            {
                if (listOfSpecials[i].ContainsItem(input))
                {
                    listOfSpecials.RemoveAt(i);
                }
                i++;
            }
        }
    }
}
