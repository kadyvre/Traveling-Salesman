using System;
using System.Text;

namespace CodingActivity_TheTravelingSalesperson
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Salesperson object for the Controller to use
        // Note: There is no need for a Salesperson property given the Controller already 
        //       has access to the same Salesperson object.
        //
        private Salesperson _salesperson;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Salesperson salesperson)
        {
            _salesperson = salesperson;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "- Welcome to the Salesperson game -";
            ConsoleUtil.HeaderText = " - The Traveling Salesperson -";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for playing my game. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("- Welcome to the Traveling Salesperson -");
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("You are a traveling salesperson, your first task will be to set up your account details.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new salesperson object with the initial data
        /// Note: To maintain the pattern of only the Controller changing the data this method should
        ///       return a Salesperson object with the initial data to the controller. For simplicity in 
        ///       this demo, the ConsoleView object is allowed to access the Salesperson object's properties.
        /// </summary>
        public void DisplaySetupAccount()
        {
            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Setup your account now.");
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("What is your first name? ");
            Console.WriteLine("");
            _salesperson.FirstName = Console.ReadLine();
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("What is your last name? ");
            Console.WriteLine("");
            _salesperson.LastName = Console.ReadLine();
            Console.WriteLine();

            // Age validation
            int age;
            bool validAge = false;

            while (!validAge)
            {
                ConsoleUtil.DisplayPromptMessage("How old are you? ");
                Console.WriteLine("");
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    if (age > 0 && age < 130)
                    {
                        _salesperson.Age = age;
                        validAge = true;
                    }
                    else
                    {
                        Console.WriteLine("Come on now, this isn't that hard...");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter your age as a number between 0 and 130 (1, 2, 3, etc...)");
                }
            }
            //End of age validation

            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Make an account ID ");
            Console.WriteLine("");
            _salesperson.Accountnumber = Console.ReadLine();
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("What kind of product are you selling?");
            Console.WriteLine("");
            _salesperson.ProductName = Console.ReadLine();
            Console.WriteLine();

            // TODO prompt the user to input all of the required account information
            //

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a closing screen when the user quits the application
        /// </summary>
        public void DisplayClosingScreen()
        {
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("- Thank you for playing -");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            //
            // TODO enable each application function separately and test
            //
            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + $"1. Buy {_salesperson.ProductName}" + Environment.NewLine +
                    "\t" + $"2. Sell {_salesperson.ProductName}" + Environment.NewLine +
                    "\t" + $"3. Display {_salesperson.ProductName} in stock" + Environment.NewLine +
                    "\t" + "4. Travel to a new city" + Environment.NewLine +
                    "\t" + "5. Display cities traveled to" + Environment.NewLine +
                    "\t" + "6. Display Account Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.Sell;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.DisplayInventory;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        //
                        // TODO handle invalid menu responses from user
                        //
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }
        /// <summary>
        /// get the next city to travel to from the user
        /// </summary>
        /// <returns>string City</returns>
        public string DisplayGetNextCity()
        {
            string nextCity = "";

            ConsoleUtil.HeaderText = "Next City of Travel";
            ConsoleUtil.DisplayReset();

            Console.WriteLine("Choose the next city");

            nextCity = Console.ReadLine();

            DisplayContinuePrompt();

            return nextCity;
        }

        /// <summary>
        /// get the number of widget units to buy from the user
        /// </summary>
        /// <returns>int number of units to buy</returns>
        public int DisplayGetNumberOfUnitsToBuy()
        {
            int numberOfUnitsToAdd = 0;
            bool validNumberToAdd = false;

            ConsoleUtil.HeaderText = "Buy Inventory";
            ConsoleUtil.DisplayReset();

            while (!validNumberToAdd)
            {
                Console.Write($"How many {_salesperson.ProductName} would you like to buy?");
                Console.WriteLine("");

                if (int.TryParse(Console.ReadLine(), out numberOfUnitsToAdd))
                {
                    if (numberOfUnitsToAdd > 0)
                    {
                        validNumberToAdd = true;

                    }
                    else
                    {
                        Console.WriteLine("Please enter a number that is above 0");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number that is above 0");
                }
            }

            

            DisplayContinuePrompt();

            return numberOfUnitsToAdd;


        }

        /// <summary>
        /// get the number of widget units to sell from the user
        /// </summary>
        /// <returns>int number of units to buy</returns>
        public int DisplayGetNumberOfUnitsToSell()
        {
            int numberOfUnitsToSell = _salesperson.ProductUnits;
            bool validNumberToSubtract = false;

            ConsoleUtil.HeaderText = "Sell Inventory";
            ConsoleUtil.DisplayReset();

            if (numberOfUnitsToSell <= 0)
            {
                Console.WriteLine($"You don't have any {_salesperson.ProductName} to sell, go buy some.");
            }

            else
            {
                while (!validNumberToSubtract)
                {
                    Console.WriteLine($"You have {_salesperson.ProductUnits} {_salesperson.ProductName}");
                    ConsoleUtil.DisplayPromptMessage("How many would you like to sell?");
                    Console.WriteLine("");

                        if (int.TryParse(Console.ReadLine(), out numberOfUnitsToSell))
                        {
                            if (numberOfUnitsToSell > 0 && numberOfUnitsToSell <= _salesperson.ProductUnits)
                            {
                                 validNumberToSubtract = true;
                             }
                            else
                            {
                                Console.WriteLine($"You do not have that many {_salesperson.ProductName} to sell.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Please enter the amount of {_salesperson.ProductName} you wish to sell as a positive whole number.");
                    }
                }              
            }

            Console.WriteLine($"You sold  {numberOfUnitsToSell} {_salesperson.ProductName}(s)");

            DisplayContinuePrompt();

            return numberOfUnitsToSell;
        }

        /// <summary>
        /// display the current inventory
        /// </summary>
        public void DisplayInventory()
        {
            ConsoleUtil.HeaderText = "Current Inventory";
            ConsoleUtil.DisplayReset();

            Console.WriteLine($"Number of {_salesperson.ProductName}: {_salesperson.ProductUnits}");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of the cities traveled
        /// </summary>
        public void DisplayCitiesTraveled()
        {
            ConsoleUtil.HeaderText = "Cities Traveled To";
            ConsoleUtil.DisplayReset();

            foreach (string city in _salesperson.LocationsVisited)
            {
                Console.WriteLine(city);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayAccountInfo()
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();

            Console.WriteLine("First Name: " + _salesperson.FirstName);
            Console.WriteLine("Last Name: " + _salesperson.LastName);
            Console.WriteLine("Age: " + _salesperson.Age);
            Console.WriteLine("Account ID: " + _salesperson.Accountnumber);
            Console.WriteLine("Product: " + _salesperson.ProductName);

            DisplayContinuePrompt();
        }

        #endregion
    }
}
