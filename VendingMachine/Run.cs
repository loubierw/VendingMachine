using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VendingMachine.VendingMachine;

namespace VendingMachine
{
    /// <summary>
    /// Runs vending machine
    /// </summary>
    class Run
    {
        /// <summary>
        /// The vending machine we will run
        /// </summary>
        static VendingMachine vendingMachine;

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Console arguments</param>
        static void Main(string[] args)
        {
            while (true)
            {
                vendingMachine = new VendingMachine();
                Console.Clear();
                vendingMachine.InteractWithUser();
            }
        }
    }
}