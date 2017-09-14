using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Base class for food in vending machine
    /// </summary>
    public abstract class Food : IFood
    {
        /// <summary>
        /// Price of food
        /// </summary>
        protected double Price;

        /// <summary>
        /// Name of food
        /// </summary>
        protected string Name;

        /// <summary>
        /// <see cref="IFood.GetName"/>
        /// </summary>
        /// <returns>Name of food</returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// <see cref="IFood.GetPrice"/>
        /// </summary>
        /// <returns>Price of food</returns>
        public double GetPrice()
        {
            return Price;
        }

        /// <summary>
        /// Descibes how food is consumed
        /// </summary>
        /// <returns>Consume method</returns>
        public abstract string Consume();
    }
}