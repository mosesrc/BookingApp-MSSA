using System;

namespace BookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager1 = new Manager("Ryan", "Moses", 30, "password");
            Calendar FirstQuarter = new Calendar();
            DataSource studioDatabase = new DataSource();
            string userInput;
            bool passValidate;

            do
            {
                try
                {

                    Console.Write("Hello are you a Manager or Student?  Please answer by typing \"M\" or \"S\":  ");
                    userInput = Console.ReadLine().ToUpper();

                    if (userInput == "M")
                    {
                        passValidate = manager1.PasswordCheck();
                        Console.WriteLine(manager1);
                        switch (manager1.ManagerMenu())
                        {
                            case 1:
                                manager1.AddInstructor(studioDatabase);
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            case 9:
                                break;
                            case 10:
                                break;

                        }



                    }
                    else if (userInput == "S")
                    {
                        // Run book a lesson
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


        }
    }
}

