﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gzhao_checkout_total
{
    /// <summary>
    /// The database of Items and Specials within the shop.
    /// </summary>
    class Database
    {
        private static List<Item> listOfItems = new List<Item>();
        private static List<Special> listOfSpecials = new List<Special>();

        /// <summary>
        /// Get the total number of items currently in the database.
        /// </summary>
        /// <returns></returns>
        internal static int GetItemCount()
        {
            return listOfItems.Count;
        }

        /// <summary>
        /// Gets the first instance of this item from the list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static Item GetItem(string name)
        {
            int itemTgt = -1;
            int i = 0;
            while (itemTgt == -1 && i < listOfItems.Count)
            {
                if (listOfItems[i].Match(name))
                {
                    itemTgt = i;
                }
                i++;
            }

            return listOfItems[itemTgt];
        }

        /// <summary>
        /// Gets an item at the given pointer.
        /// If there's an overflow, it simply returns the first item.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        internal static Item GetItemAt(int i)
        {
            int j = i;
            if(j > listOfItems.Count)
            {
                j = 0;
            }
            return listOfItems[j];
        }

        /// <summary>
        /// Adds an item into the list of Items.
        /// Duplicates are ignored.
        /// </summary>
        /// <param name="newItem"></param>
        internal static void AddItem(Item newItem)
        {
            int i = 0;
            bool exists = false;
            while(!exists && i < listOfItems.Count)
            {
                exists = listOfItems[i].Match(newItem.name);
                i++;
            }

            if (!exists)
            {
                listOfItems.Add(newItem);
            }
        }

        /// <summary>
        /// Removes all instances of an item with the given name from the list 
        /// of items.
        /// </summary>
        /// <param name="name"></param>
        internal static void RemoveItem(string name)
        {
            int i = listOfItems.Count - 1;
            while (i >= 0)
            {
                if (listOfItems[i].Match(name))
                {
                    listOfItems.RemoveAt(i);
                }
                i--;
            }
        }

        /// <summary>
        /// Returns the price of an item given its name.
        /// Will return 0 if the name is not in the list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static float GetCost(string name)
        {
            float value = 0.0f;

            foreach (Item item in listOfItems)
            {
                if (item.Match(name))
                {
                    value = item.price;
                }
            }

            return value;
        }

        /// <summary>
        /// Clean the list of items entirely.
        /// </summary>
        internal static void PurgeItems()
        {
            listOfItems = new List<Item>();
        }

        /// <summary>
        /// Adds a special to the database of specials.
        /// If there exists a special that affects the same item as the new
        /// incoming special, the old one is removed in favor of the new one.
        /// </summary>
        /// <param name="s"></param>
        internal static void AddSpecial(Special s)
        {
            int i = listOfSpecials.Count;
            bool changed = false;
            while(i > 0 && !changed)
            {
                i--;
                if (listOfSpecials[i].Match(s.itemAffected))
                {
                    listOfSpecials.RemoveAt(i);
                    listOfSpecials.Add(s);
                    changed = true;
                }
            }

            //If it's just not in the list.
            if (!changed)
            {
                listOfSpecials.Add(s);
            }
        }

        /// <summary>
        /// Removes all specials that affect the item with the given name.
        /// </summary>
        /// <param name="name"></param>
        internal static void RemoveSpecial(string name)
        {
            int i = listOfSpecials.Count;
            while (i > 0)
            {
                i--;
                if (listOfSpecials[i].Match(name))
                {
                    listOfSpecials.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Gets the total count of specials in the list.
        /// </summary>
        /// <returns></returns>
        internal static int GetSpecialCount()
        {
            return listOfSpecials.Count;
        }

        /// <summary>
        /// Gets a special at the given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal static Special GetSpecialAt(int position)
        {
            return listOfSpecials[position];
        }
    }
}
