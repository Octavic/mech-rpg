//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WeightedList.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines  a weighted list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WeightedList<T>
    {
        /// <summary>
        /// The internal list
        /// </summary>
        private Dictionary<T, int> items;

        /// <summary>
        /// The total weight
        /// </summary>
        private int totalWeight;

        /// <summary>
        /// Creates a new instance of the <see cref="WeightedList{T}"/> class
        /// </summary>
        public WeightedList()
        {
            this.items = new Dictionary<T, int>();
        }

        /// <summary>
        /// Get the weight for the item
        /// </summary>
        /// <param name="item">Target item</param>
        /// <returns>The weight, 0 if none</returns>
        public int GetWeight(T item)
        {
            int existWeight;
            if (this.items.TryGetValue(item, out existWeight))
            {
                return existWeight;
            }

            return 0;
        }

        /// <summary>
        /// Adds a  new item
        /// </summary>
        /// <param name="item">Target item to be added</param>
        /// <param name="weight">Target item's weight</param>
        public void AddItem(T item, int weight)
        {
            this.totalWeight += weight;

            if (this.items.ContainsKey(item))
            {
                this.items[item] += weight;
            }
            else
            {
                this.items[item] = weight;
            }
        }

        /// <summary>
        /// Removes a given amount of weight from  the item
        /// </summary>
        /// <param name="item">Target item</param>
        /// <param name="weight">desired weight to be removed</param>
        public void RemoveItem(T item, int weight)
        {
            var diff = this.GetWeight(item) - weight;
            if (diff< 0)
            {
                throw new IndexOutOfRangeException("Item doesn't exist or does not have enough weight");
            }

            if (diff - weight == 0)
            {
                this.items.Remove(item);
            }

            this.items[item] = diff;
            this.totalWeight -= weight;
        }

        /// <summary>
        /// Gets a random item
        /// </summary>
        /// <returns>The result item</returns>
        public T GetItem()
        {
            var stoppingPoint = GlobalRandom.Next(this.totalWeight);
            foreach(var item in this.items.ToList())
            {
                if (stoppingPoint < item.Value)
                {
                    return item.Key;
                }

                stoppingPoint -= item.Value;
            }

            throw new Exception("Error getting item");
        }
    }
}
