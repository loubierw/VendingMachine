using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    /// <summary>
    /// Tests for Food subclasses
    /// </summary>
    [TestClass]
    public class FoodTest
    {
        /// <summary>
        /// Tests that values set in Chips class are as expected
        /// </summary>
        [TestMethod]
        public void Chips_GetValues()
        {
            Food food = new Chips();
            Assert.AreEqual("Chips", food.GetName());
            Assert.AreEqual(1, food.GetPrice());

            string expectedValue = food.Consume();
            Assert.AreEqual(expectedValue, "eat");
        }

        /// <summary>
        /// Tests that values set in Soda class are as expected
        /// </summary>
        [TestMethod]
        public void Soda_GetValues()
        {
            Food food = new Soda();
            Assert.AreEqual("Soda", food.GetName());
            Assert.AreEqual(1.5, food.GetPrice());

            string expectedValue = food.Consume();
            Assert.AreEqual(expectedValue, "drink");
        }

        /// <summary>
        /// Tests that values set in Candy class are as expected
        /// </summary>
        [TestMethod]
        public void Candy_GetValues()
        {
            Food food = new Candy();
            Assert.AreEqual("Candy", food.GetName());
            Assert.AreEqual(.75, food.GetPrice());

            string expectedValue = food.Consume();
            Assert.AreEqual(expectedValue, "eat");
        }

    }
}
