using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Chips in vending machine
    /// </summary>
    public class Chips : Food
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Chips()
        {
            Price = 1;
            Name = "Chips";
        }

        /// <summary>
        /// <see cref="Food.Consume"/>
        /// </summary>
        /// <returns>Chips consumption method</returns>
        public override string Consume()
        {
            return "eat";
        }
    }
}
