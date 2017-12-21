﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class UI
    {
        public static void DisplayIntroScreen()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("WELCOME TO A.R. HUMANE SOCIETY");
            Console.ResetColor();
            Console.WriteLine("Instructions to come...");

        }

        public static string GetAddAnimalOption(bool allowAll)
        {
            string menuOptions = GetAddAnimalMenu(allowAll);
            DisplayMenu(menuOptions);
            List<string> menuNumbers = GetMenuNumbers(menuOptions);
            DisplayMenuHeader();
            return GetValidUserOption("", menuNumbers);
        }

        public static string GetAnimalName(bool allowNone)
        {
            Console.Write("\nEnter an animal Name");
            if (allowNone)
            {
                Console.WriteLine(" (or leave blank)");
            }
            Console.WriteLine(":");
            return Console.ReadLine();
        }

        public static string GetAnimalRoomNumber(bool allowNone)
        {
            Console.Write("\nEnter a room number for the animal");
            if (allowNone)
            {
                Console.WriteLine(" (or leave blank)");
            }
            Console.WriteLine(":");
            string userInput = Console.ReadLine();
            int roomNumber;
            if (!int.TryParse(userInput, out roomNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter number!");
                Console.ResetColor();
                return GetAnimalRoomNumber(allowNone);
            }
            else
            {
                return roomNumber.ToString();
            }
        }

        public static string GetImmunizationStatus(bool isSearchingAnimal)
        {
            if (!isSearchingAnimal)
            {
                Console.WriteLine("\nHas the animal been immunized?");
            }
            else
            {
                Console.WriteLine("\nLimit search to immunized animals?");
            }
            return GetValidUserOption("", new List<string> {"y", "n"});
        }

        public static void DisplayMenuHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMenu Options==================================");
            Console.ResetColor();
        }

        public static void DisplayValidOptions(List<string> validOptions)
        {
            Console.Write("Enter ");
            for (int i = 0; i < validOptions.Count; i++)
            {
                if (i == validOptions.Count - 1)
                {
                    Console.Write(" or ");
                }
                Console.Write("'");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(validOptions[i]);
                Console.ResetColor();
                Console.Write("'");
                if (i < validOptions.Count - 2)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }


        static string GetMainMenu(string role)
        {
            StringBuilder menuOptions = new StringBuilder();
            if (role == "employee")
            {
                menuOptions.Append("1: Add Animal to Database\n");
                menuOptions.Append("2: Search Animals\n");
                menuOptions.Append("3: List All Animals\n");
                menuOptions.Append("4: Search Adopters\n");
                menuOptions.Append("5: List All Adopters\n");
            }
            else
            {
                menuOptions.Append("1: Create/Edit Profile\n");
                menuOptions.Append("2: Search Animals\n");
                menuOptions.Append("3: List All Animals\n");
            }
            menuOptions.Append("q: Quit Application");
            return menuOptions.ToString();
        }

        static string GetAddAnimalMenu(bool allowAll)
        {
            StringBuilder menuOptions = new StringBuilder();
            menuOptions.Append("1: Dog\n");
            menuOptions.Append("2: Cat\n");
            menuOptions.Append("3: Bird\n");
            menuOptions.Append("4: Rabbit\n");
            menuOptions.Append("5: Ferret\n");
            if (allowAll)
            {
                menuOptions.Append("6: All\n");
            }
            menuOptions.Append("m: Return to Main Menu\n");
            menuOptions.Append("q: Quit Application");
            return menuOptions.ToString();
        }

        public static void DisplayPageHeader(string header)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(header.ToUpper());
            Console.ResetColor();
        }

        static List<string> GetMenuNumbers(string menuOptions)
        {
            List<string> menuNumbers = new List<string>();
            string[] menuLines = menuOptions.Split(
                new[] { "\n" },
                StringSplitOptions.None
            );
            for (int i=0; i<menuLines.Length; i++ )
            {
                menuNumbers.Add(menuLines[i][0].ToString());
            }
            return menuNumbers;
        }

        static void DisplayMenu(string menuOptions)
        {
            Console.WriteLine(menuOptions);
        }

        public static string GetMainMenuOptions(string role)
        {
            DisplayPageHeader(role + " MAIN MENU");
            string menuOptions = GetMainMenu(role);
            DisplayMenu(menuOptions);
            List<string> menuNumbers = GetMenuNumbers(menuOptions);
            DisplayMenuHeader();
            return GetValidUserOption("", menuNumbers);
        }

        public static string GetValidUserOption(string instruction, List<string> validOptions)
        {
            Console.WriteLine(instruction);
            DisplayValidOptions(validOptions);
            string userInput = Console.ReadLine();
            if (!validOptions.Contains(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("'{0}' is an invalid option. Please read the instructions.", userInput);
                Console.ResetColor();
                return GetValidUserOption(instruction, validOptions);
            }
            Console.WriteLine();
            return userInput;
        }


    }
}
