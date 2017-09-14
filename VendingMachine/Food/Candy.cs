using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Candy in vending machine
    /// </summary>
    public class Candy : Food
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Candy()
        {
            Price = 0.75;
            Name = "Candy";
        }

        /// <summary>
        /// <see cref="Food.Consume"/>
        /// </summary>
        /// <returns>Candy consumption method</returns>
        public override string Consume()
        {
            return "eat";
        }
    }
}
