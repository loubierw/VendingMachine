using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Soda in vending machine
    /// </summary>
    public class Soda : Food
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Soda()
        {
            Price = 1.5;
            Name = "Soda";
        }

        /// <summary>
        /// <see cref="Food.Consume"/>
        /// </summary>
        /// <returns>Soda consumption method</returns>
        public override string Consume()
        {
            return "drink";
        }
    }
}
