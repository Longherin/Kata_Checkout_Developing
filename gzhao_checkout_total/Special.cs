using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    /// <summary>
    /// A special is a deal that exists for a certain amount of items.
    /// </summary>
    class Special
    {
        /// <summary>
        /// Not used for this demonstration, but this would be used for cases like
        /// where deals are applied for company-wide products rather than just single
        /// products.
        /// </summary>
        private List<string> tags;

        /// <summary>
        /// All the items that are a part of this deal.
        /// </summary>
        private List<string> affectedItems;

        /// <summary>
        /// How many items are affected by this special.
        /// </summary>
        private int affectedNumbers;

        /// <summary>
        /// How many items are needed before this special can be applied.
        /// </summary>
        private int affectedLimit;

        /// <summary>
        /// How many items in total can be affected by this special.
        /// </summary>
        private int affectedStart;

        /// <summary>
        /// The description of the deal.
        /// </summary>
        public string description { get; private set; }

        /// <summary>
        /// Create a new special deal.
        /// </summary>
        /// <param name="input">The description of the deal.</param>
        /// <param name="numbers">How many items will be affected. -1 means 'all of it'.</param>
        /// <param name="start">How many items are needed to start the deal. -1 means 'all of it.'</param>
        /// <param name="limit">How many items in total are considered for this deal.</param>
        public Special(string input, int numbers=-1, int start=-1, int limit=0)
        {
            description = input;
            affectedNumbers = numbers;
            affectedLimit = limit;
            affectedStart = start;
        }

        /// <summary>
        /// Check if this special applies to the item given.
        /// Returns true if that is the case.
        /// </summary>
        /// <param name="input">The name of the item being given.</param>
        /// <returns>Whether if the item applies to this special.</returns>
        public bool ContainsItem(string input)
        {
            return affectedItems.Contains(input);
        }
    }
}
