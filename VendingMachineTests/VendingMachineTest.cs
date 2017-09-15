using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineTests
{
    /// <summary>
    /// Tests for VendingMachine class
    /// </summary>
    [TestClass]
    public class VendingMachineTest
    {
        /// <summary>
        /// VendingMachine Class being tested
        /// </summary>
        private TestVendingMachine vendingMachine;

        /// <summary>
        /// Runs before each test
        /// </summary>
        [TestInitialize]
        public void Before()
        {
            vendingMachine = new TestVendingMachine();
        }

        /// <summary>
        /// Tests that selection status is valid and no change is returned
        /// </summary>
        [TestMethod]
        public void VendingMachine_ProcessSelection_Valid_NoChange()
        {
            vendingMachine.Selection = 1;
            vendingMachine.AmountPaid = 1;
            VendingMachine.VendingMachine.VendStatus returnedStatus =
            vendingMachine.ProcessSelection();
            Assert.AreEqual(0, vendingMachine.Change);
            Assert.AreEqual(VendingMachine.VendingMachine.VendStatus.Valid, returnedStatus);
            Food expectedFood = new Chips();
            Assert.AreEqual(expectedFood.GetName(), vendingMachine.SelectedFood.GetName());
        }

        /// <summary>
        /// Tests that selection status is valid and that change is returned
        /// </summary>
        [TestMethod]
        public void VendingMachine_ProcessSelection_Valid_Change()
        {
            vendingMachine.Selection = 3;
            vendingMachine.AmountPaid = 1;
            VendingMachine.VendingMachine.VendStatus returnedStatus =
            vendingMachine.ProcessSelection();
            Assert.AreEqual(0.25, vendingMachine.Change);
            Assert.AreEqual(VendingMachine.VendingMachine.VendStatus.Valid, returnedStatus);
            Food expectedFood = new Candy();
            Assert.AreEqual(expectedFood.GetName(), vendingMachine.SelectedFood.GetName());
        }

        /// <summary>
        /// Tests that selection status is invalid
        /// </summary>
        [TestMethod]
        public void VendingMachine_ProcessSelection_Invalid()
        {
            vendingMachine.Selection = 5;
            vendingMachine.AmountPaid = 1;
            VendingMachine.VendingMachine.VendStatus returnedStatus =
            vendingMachine.ProcessSelection();
            Assert.AreEqual(VendingMachine.VendingMachine.VendStatus.Invalid, returnedStatus);
        }

        /// <summary>
        /// Tests that status is more money
        /// </summary>
        [TestMethod]
        public void VendingMachine_ProcessSelection_MoreMoney()
        {
            vendingMachine.Selection = 2;
            vendingMachine.AmountPaid = 1;
            VendingMachine.VendingMachine.VendStatus returnedStatus =
            vendingMachine.ProcessSelection();
            Assert.AreEqual(VendingMachine.VendingMachine.VendStatus.MoreMoney, returnedStatus);
            Food expectedFood = new Soda();
            Assert.AreEqual(expectedFood.GetName(), vendingMachine.SelectedFood.GetName());
        }

        /// <summary>
        /// Tests that messages output to user are as expected
        /// </summary>
        [TestMethod]
        public void InteractWithUser_TestInputs()
        {
            vendingMachine.UserInput.Add("a");
            vendingMachine.UserInput.Add("-1");
            vendingMachine.UserInput.Add("1");
            vendingMachine.UserInput.Add("b");
            vendingMachine.UserInput.Add("5");
            vendingMachine.UserInput.Add("2");
            vendingMachine.UserInput.Add("1");
            vendingMachine.UserInput.Add("");

            List<string> expectedOutputs = new List<string>();

            vendingMachine.InteractWithUser();

            expectedOutputs.Add(VendingMachine.VendingMachine.INITIAL_MESSAGE);
            AddMoneyString(expectedOutputs);
            AddMoneyString(expectedOutputs);

            expectedOutputs.Add("Please don't steal from me.");
            AddMoneyString(expectedOutputs);

            expectedOutputs.Add("You have inserted $1.00");

            AddSelectionString(expectedOutputs);
            AddSelectionString(expectedOutputs);

            expectedOutputs.Add("Selection invalid");
            AddSelectionString(expectedOutputs);

            expectedOutputs.Add("You need to insert $0.50");
            AddMoneyString(expectedOutputs);

            expectedOutputs.Add("You have inserted $2.00");
            expectedOutputs.Add("Here is your Soda to drink");
            expectedOutputs.Add("Here is your change $0.50");
            expectedOutputs.Add("Have a good day!");

            Assert.IsTrue(expectedOutputs.SequenceEqual(vendingMachine.Messages));
        }

        /// <summary>
        /// Helper method to selection string to output list
        /// </summary>
        /// <param name="outputList">List of output messages</param>
        private void AddSelectionString(List<string> outputList)
        {
            outputList.Add(VendingMachine.VendingMachine.SELECTION_STRING);
        }

        /// <summary>
        /// Helper method to money string to output list
        /// </summary>
        /// <param name="outputList">List of output messages</param>
        private void AddMoneyString(List<string> outputList)
        {
            outputList.Add(VendingMachine.VendingMachine.MONEY_STRING);
        }

    }

    /// <summary>
    /// TestVendingMachine class to override methods that interact with Console
    /// </summary>
    public class TestVendingMachine : VendingMachine.VendingMachine
    {
        /// <summary>
        /// Messages being displayed to user
        /// </summary>
        public List<string> Messages;

        /// <summary>
        /// User inputs
        /// </summary>
        public List<string> UserInput { get; set; }

        /// <summary>
        /// Index of user input list
        /// </summary>
        int inputIndex;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TestVendingMachine()
        {
            Messages = new List<string>();
            inputIndex = 0;
            UserInput = new List<string>();
        }

        /// <summary>
        /// Adds messages to list
        /// </summary>
        /// <param name="message">Message to dispay to user</param>
        public override void DisplayToUser(string message)
        {
            Messages.Add(message);
        }

        /// <summary>
        /// Returns user input at current index
        /// </summary>
        /// <returns>User input string</returns>
        public override string GetUserInput()
        {
            string input = UserInput.ElementAt(inputIndex);
            inputIndex++;
            return input;
        }
    }
}
