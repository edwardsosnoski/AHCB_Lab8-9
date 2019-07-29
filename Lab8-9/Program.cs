using System;
using System.Collections.Generic;

namespace Lab8_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> studentNames = new List<string>()
            {
                "Ted",
                "Bill",
                "Sally",
                "Jimbo",
                "Molly"
            };

            List<string> studentHometown = new List<string>()
            {
                "Detroit",
                "New York",
                "Los Angeles",
                "Seattle",
                "Dallas"
            };

            List<string> studentFavoriteFood = new List<string>()
            {
                "Pizza",
                "Ice Cream",
                "Candy",
                "Nachos",
                "Escargot"
            };

            List<string> studentFavoriteColor = new List<string>()
            {
                "Red",
                "Blue",
                "Yellow",
                "Green",
                "Black"
            };

            string action = PickAnAction(
                "Would you like to see \"hometown\", see \"favorite food\", see \"favorite color\", or add a \"new student\"?",
                "That is not a valid entry.");

            if (action.Equals("favorite food"))
            {
                bool continuePrompt = true;
                while(continuePrompt)
                {
                    int student = PickAStudent(studentNames);
                    Console.WriteLine($"{studentNames[student]}'s favorite food is {studentFavoriteFood[student]}.");
                    continuePrompt = ValidateYesOrNo("Would you like to learn more? Enter \"yes\" or \"no\"", "That is not a valid entry.");
                }
            }
            else if (action.Equals("hometown"))
            {
                bool continuePrompt = true;
                while (continuePrompt)
                {
                    int student = PickAStudent(studentNames);
                    Console.WriteLine($"{studentNames[student]}'s hometown is {studentHometown[student]}.");
                    continuePrompt = ValidateYesOrNo("Would you like to learn more? Enter \"yes\" or \"no\"", "That is not a valid entry.");
                }
            }
            else if (action.Equals("favorite color"))
            {
                bool continuePrompt = true;
                while (continuePrompt)
                {
                    int student = PickAStudent(studentNames);
                    Console.WriteLine($"{studentNames[student]}'s favorite color is {studentFavoriteColor[student]}.");
                    continuePrompt = ValidateYesOrNo("Would you like to learn more? Enter \"yes\" or \"no\"", "That is not a valid entry.");
                }
            }
            else
            {
                Console.WriteLine("Enter the student's name:");
                studentNames.Add(Console.ReadLine());
                Console.WriteLine("Enter the student's hometown:");
                studentHometown.Add(Console.ReadLine());
                Console.WriteLine("Enter the student's favorite food:");
                studentFavoriteFood.Add(Console.ReadLine());
                Console.WriteLine("Enter the student's favorite color:");
                studentFavoriteColor.Add(Console.ReadLine());

                Console.WriteLine("New student info:");
                Console.WriteLine($"Name: {studentNames[(studentNames.Count-1)]}");
                Console.WriteLine($"Hometown: {studentHometown[(studentHometown.Count-1)]}");
                Console.WriteLine($"Favorite Food: {studentFavoriteFood[(studentFavoriteFood.Count-1)]}");
                Console.WriteLine($"Favorite Color: {studentFavoriteColor[(studentFavoriteColor.Count-1)]}");
            }
        }

        static int ValidateIntegerInput(string messageToUser, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(messageToUser);
                bool userInput = int.TryParse(Console.ReadLine(), out int result);

                if (userInput)
                {
                    if (result > 0 && result < 6)
                    {
                        return result - 1;
                    }
                }

                Console.WriteLine(errorMessage);
            }
        }

        static bool ValidateYesOrNo(string messageToUser, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(messageToUser);
                string userInput = Console.ReadLine();

                if (userInput.Equals("yes"))
                {
                    bool userResponse = true;
                    return userResponse;
                }
                else if (userInput.Equals("no"))
                {
                    bool userResponse = false;
                    return userResponse;
                }

                Console.Write(errorMessage);
            }
        }

        static int PickAStudent(List<string> studentList)
        {
            int nameIndex = ValidateIntegerInput(
                "What student would you like to learn about? Enter a number between 1-5:",
                "That was not a valid choice.");

            return nameIndex;
        }

        static string PickAnAction(string userMessage, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(userMessage);
                string userInput = Console.ReadLine();

                if (userInput.Equals("favorite food") || userInput.Equals("hometown") || userInput.Equals("favorite color") || userInput.Equals("new student"))
                {
                    return userInput;
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}