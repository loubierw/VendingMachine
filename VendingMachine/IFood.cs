using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Interface for food
    /// </summary>
    public interface IFood
    {
        /// <summary>
        /// Returns price of food
        /// </summary>
        /// <returns>Food price</returns>
        double GetPrice();

        /// <summary>
        /// Returns name of food
        /// </summary>
        /// <returns>Food name</returns>
        string GetName();
    }
}