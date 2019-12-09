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
        /// The name of the item affected.
        /// </summary>
        public string itemAffected { get; private set; }
        
        /// <summary>
        /// The type of a special.
        /// FIXED = Set the affected item(s) to a fixed price.
        /// PERCENTAGE = Set the affected item(s) to a percentage of their original price.
        /// </summary>
        public enum SPECIAL_TYPE : int {FIXED = 0, PERCENTAGE = 1}

        /// <summary>
        /// The type of this special.
        /// </summary>
        private readonly SPECIAL_TYPE type;
        
        /// <summary>
        /// The amount that this item is either:
        /// FIXED = Set to
        /// PERCENTAGE = Reduced by.
        /// 
        /// Note: for PERCENTAGE, 20 = 20% reduction in price.
        /// </summary>
        public float costChange { get; private set; }

        /// <summary>
        /// The amount of items that need to be purchased before this special fires.
        /// </summary>
        public int activationRequirement { get; private set; }

        /// <summary>
        /// The amount of items that this special applies to.
        /// </summary>
        public int appliedToAmount { get; private set; }

        public Special()
        {
            itemAffected = "_NULL_ITEM";
            type = SPECIAL_TYPE.FIXED;
            costChange = 0;
            activationRequirement = 255;
            appliedToAmount = 0;
        }

        /// <summary>
        /// Creates a new Special Deal.
        /// </summary>
        /// <param name="sp_name">The name of the item that this deal affects.</param>
        /// <param name="specialType">The type of the special.</param>
        /// <param name="cost">The change in value for this item.</param>
        /// <param name="activateReq">How many we need before this special is applied.</param>
        /// <param name="appliedAmt">How many items get applied this special after it activates.</param>
        public Special(string sp_name, int specialType, float cost, int activateReq, int appliedAmt)
        {
            itemAffected = sp_name;
            type = (SPECIAL_TYPE)specialType;
            costChange = cost;
            activationRequirement = activateReq;
            appliedToAmount = appliedAmt;
        }
        
        /// <summary>
        /// Returns true if this Special's affected item is the same as the string being given.
        /// Case insensitive and culled for leading/trailing spaces.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Match(string name)
        {
            string temp = name.ToLower().Trim();
            return temp.Equals(itemAffected.ToLower());
        }

        /// <summary>
        /// Returns true if this special is a percentage deal rather than
        /// a fixed price change.
        /// </summary>
        /// <returns></returns>
        public bool GetIsPercentage()
        {
            bool ret = false;

            if(type == SPECIAL_TYPE.PERCENTAGE)
            {
                ret = true;
            }

            return ret;
        }
    }
}
