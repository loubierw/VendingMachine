using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    /// <summary>
    /// Vending machine user is interacting with
    /// </summary>
    public class VendingMachine
    {
        /// <summary>
        /// Amount of money the user has inserted
        /// </summary>
        public double AmountPaid { get; set; }

        /// <summary>
        /// The selection the user has made
        /// </summary>
        public int Selection { get; set; }

        /// <summary>
        /// The change to be returned to the user
        /// </summary>
        public double Change { get; private set; }

        /// <summary>
        /// The price of the selected item
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// The food to be vended to the user
        /// </summary>
        public Food SelectedFood { get; private set; }

        /// <summary>
        /// Status of vend after the selection is made by the user:
        /// Valid means the selected number is valid and the user has inserted enough money
        /// Invalid means the selected number is not valid
        /// MoreMoney means the user has not inserted enough money for the selection made
        /// </summary>
        public enum VendStatus { Valid, Invalid, MoreMoney };

        /// <summary>
        /// Prompt asking user to make a selection
        /// </summary>
        public const string SELECTION_STRING = "Please make a selection";

        /// <summary>
        /// Prompt asking user to insert money
        /// </summary>
        public const string MONEY_STRING = "Please insert money";

        /// <summary>
        /// Default constructor
        /// </summary>
        public VendingMachine()
        {
            AmountPaid = 0;
            Selection = 0;
            Change = 0;
            SelectedFood = null;
        }

        /// <summary>
        /// Processes user selection and returns status
        /// </summary>
        /// <returns>Status of vend</returns>
        public VendStatus ProcessSelection()
        {
            Food food = null;
            switch (Selection)
            {
                case 1:
                    food = new Chips();
                    break;
                case 2:
                    food = new Soda();
                    break;
                case 3:
                    food = new Candy();
                    break;
                default:
                    return VendStatus.Invalid;
            }

            SelectedFood = food;
            Price = food.GetPrice();
            if (AmountPaid < Price)
            {
                return VendStatus.MoreMoney;
            }

            Change = AmountPaid - Price;
            return VendStatus.Valid;
        }

        /// <summary>
        /// Displays prompts to user
        /// </summary>
        public void InteractWithUser()
        {
            string initalMessage = "Welcome to the extremely limited vending machine!\n" +
                "Here are your options:\n" +
                "Chips for $1.00 - Option 1\n" +
                "Soda for $1.50 - Option 2\n" +
                "Candy for $0.75 - Option 3";

            DisplayToUser(initalMessage);

            RequestMoney();
            RequestSelection();

            VendStatus status = ProcessSelection();
            while (status != VendStatus.Valid)
            {
                if (status == VendStatus.Invalid)
                {
                    DisplayToUser("Selection invalid");
                    RequestSelection();
                }
                else if (status == VendStatus.MoreMoney)
                {
                    double remaining = Price - AmountPaid;
                    DisplayToUser("You need to insert $" + remaining.ToString("0.00"));
                    RequestMoney();
                }

                status = ProcessSelection();
            }

            FinishTransaction();
        }

        /// <summary>
        /// Vends selected food to user and gives change if any
        /// </summary>
        private void FinishTransaction()
        {
            Food selectedFood = SelectedFood;
            DisplayToUser("Here is your " + selectedFood.GetName() + " to " +
                selectedFood.Consume());

            double change = Change;
            if (change > 0)
            {
                DisplayToUser("Here is your change $" + change.ToString("0.00"));
            }

            DisplayToUser("Have a good day!");
            GetUserInput();
        }

        /// <summary>
        /// Prompts user to insert money
        /// </summary>
        private void RequestMoney()
        {
            DisplayToUser(MONEY_STRING);

            double money;
            if (!double.TryParse(GetUserInput(), out money))
            {
                RequestMoney();
            }
            else if (money < 0)
            {
                DisplayToUser("Please don't steal from me.");
                RequestMoney();
            }
            else
            {
                AmountPaid = AmountPaid + money;
                DisplayToUser("You have inserted $" + AmountPaid.ToString("0.00"));
            }
        }

        /// <summary>
        /// Prompts user to make a selection
        /// </summary>
        private void RequestSelection()
        {
            DisplayToUser(SELECTION_STRING);

            int choice;
            if (!int.TryParse(GetUserInput(), out choice))
            {
                RequestSelection();
            }
            Selection = choice;
        }

        /// <summary>
        /// Displays message to user via the console
        /// </summary>
        /// <param name="message">The message to display</param>
        public virtual void DisplayToUser(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Returns user inputs from console
        /// </summary>
        /// <returns>User input</returns>
        public virtual string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}