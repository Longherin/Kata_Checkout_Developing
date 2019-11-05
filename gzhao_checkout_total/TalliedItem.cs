namespace Gzhao_checkout_total
{
    /// <summary>
    /// Each tallied item is one entry in the order.
    /// </summary>
    public class TalliedItem : Item_Super
    {

        /// <summary>
        /// How many items
        /// </summary>
        internal float count { get; private set; }

        /// <summary>
        /// No count = items sold in units.
        /// </summary>
        /// <param name="itemName"></param>
        public TalliedItem(string itemName) {
            name = itemName;
            count = 1;
        }

        /// <summary>
        /// Valued = items sold by weight.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="value"></param>
        public TalliedItem(string itemName, float value)
        {
            name = itemName;
            count = value;
        }

        public override bool Match(string matchTarget)
        {
            string mt = matchTarget.ToLower();
            return mt.Equals(name.ToLower());
        }
    }
}