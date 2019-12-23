using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    class SpecialTokenManager
    {
        private List<SpecialToken> listOfTokens;

        public SpecialTokenManager()
        {
            listOfTokens = new List<SpecialToken>();
        }

        public SpecialTokenManager(List<SpecialToken> lst)
        {
            listOfTokens = lst;
        }

        /// <summary>
        /// Add a special to the manager.
        /// </summary>
        /// <param name="token">The token being added into the manager.</param>
        public void AddToken(SpecialToken token)
        {
            listOfTokens.Add(token);
        }

        public int GetTokenListSize()
        {
            return listOfTokens.Count;
        }

        /// <summary>
        /// Gets the first special in the list that matches the item type.
        /// If nothing is received, return a dummy Special.
        /// </summary>
        /// <param name="itemType">The name of the item being checked against.</param>
        public Special GetToken(string itemType)
        {
            int i = 0;
            bool get = false;
            Special special = new Special();

            while(i < listOfTokens.Count && !get)
            {
                get = listOfTokens[i].Match(itemType);
                if (get)
                {
                    special = listOfTokens[i].special;
                }
                else
                {
                    i++;
                }
            }

            return special;
        }

        /// <summary>
        /// Returns the list of SpecialTokens this manager manages.
        /// </summary>
        /// <returns></returns>
        public List<SpecialToken> GetTokensAsList()
        {
            return listOfTokens;
        }

        /// <summary>
        /// Adds a special as a token into the manager.
        /// </summary>
        /// <param name="special">The special being added.</param>
        /// <param name="i">The amount of items being managed.</param>
        public void Add(Special special, int i)
        {
            AddToken(new SpecialToken(special, i));
        }

        /// <summary>
        /// Gets the token at the given position in the roster.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public SpecialToken GetTokenAt(int i)
        {
            return listOfTokens[i];
        }
    }
}
