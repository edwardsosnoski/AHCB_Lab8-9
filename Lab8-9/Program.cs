using System;

namespace Lab8_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] studentInfo = new string[9, 3]
            {
                { "Bill Smith", "New York", "Pizza" },
                { "Bob Sauce", "Los Angeles", "Pulled Pork" },
                { "Crumbelina Bumblebee", "Detroit"," Pollen" },
                { "Smitty Jensen", "Boston", "Clam Chowder" },
                { "Aja Milan", "Venice", "Scampi" },
                { "Tallahassee Egerton", "Boise", "Chips" },
                { "Felix Felt", "Omaha", "Eggs" },
                { "Tootie Springsteen", "Columbus", "Slushies" },
                { "Apple Graham", "Washington DC", "Oatmeal" }
            };

            ReturnStudentInfo(studentInfo);
        }

        static int ValidateIntegerInput(string messageToUser, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(messageToUser);
                bool userInput = int.TryParse(Console.ReadLine(), out int result);

                if (userInput)
                {
                    if(result > 0 && result < 10)
                    {
                        return result - 1;
                    }
                }

                Console.WriteLine(errorMessage);
            }
        }

        static string ValidateInfoSelection(string messageToUser, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(messageToUser);
                string userInput = Console.ReadLine();
                bool userValidation = (userInput.Equals("hometown") || userInput.Equals("favorite food"));

                if (userValidation)
                {
                    return userInput;
                }

                Console.WriteLine(errorMessage);
            }
        }

        static bool ValidateYesOrNo (string messageToUser, string errorMessage)
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

        static void ReturnStudentInfo(string[,] studentList)
        {
            bool continuePrompt = true;
            int infoIndex;
            int nameIndex = ValidateIntegerInput(
                "What student would you like to learn about? Enter a number between 1-9:",
                "That was not a valid choice.");

            string studentName = studentList[nameIndex, 0];

            Console.WriteLine($"That student is named {studentName}.");

            while(continuePrompt)
            {
                string infoSelection = ValidateInfoSelection(
                "What would you like to learn about this student? Enter either \"favorite food\" or \"hometown\":",
                "That was not a valid choice.");

                if (infoSelection.Equals("favorite food"))
                {
                    infoIndex = 2;
                }
                else
                {
                    infoIndex = 1;
                }

                Console.WriteLine($"{studentName}'s {infoSelection} is {studentList[nameIndex, infoIndex]}.");

                continuePrompt = ValidateYesOrNo(
                        $"Would you like to learn more about {studentName}? Enter \"yes\" or \"no\".",
                        "That was not a valid response.");
            }

        }
    }
}
