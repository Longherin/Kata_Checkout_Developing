using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    public abstract class Item_Super
    {
        public string name { get; protected set; }

        /// <summary>
        /// Returns true if the given name matches the name of this item. False otherwise.
        /// </summary>
        /// <param name="matchSource">The given name.</param>
        /// <returns></returns>
        public abstract bool Match(string matchSource);
    }
}
