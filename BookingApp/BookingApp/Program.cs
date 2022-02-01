using System;

namespace BookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Manager manager1 = new Manager();
            do
            {
                try
                {

                    Console.Write("Hello are you a Manager or Student?  Please answer by typing \"M\" or \"S\"");
                    userInput = Console.ReadLine().ToUpper();

                    if (userInput == "M")
                    { 

                    }
                    else if (userInput == "S")
                    {

                    }
                    else
                    {
                        Console.WriteLine("Please enter valid input!");
                    }
                }
                catch (FormatException e)
                {

                    throw new FormatException("Please enter one of characters specified above\n\n" + e.Message);
                }


            } while (true);

            Console.WriteLine("Hello, Would you like to book a lesson with one of our teacher's? (yes / no");

            Console.WriteLine("What would you like to learn? we offer: ");

            Console.WriteLine("Your preferred days of week are?");

            Console.WriteLine("You're preferred time: ");

        }
    }
}

