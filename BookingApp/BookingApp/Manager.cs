using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp
{
    class Manager : Person
    {
        //Member variables
        private string _managerId;
        private string _password;
        private int _count = 1;

        // Constructor
        public Manager(string fName, string lName, int age, string password)
        {
            Age = age;
            FirstName = fName;
            LastName = lName;
            ManagerId = (Age + LastName[0] + Count).ToString();
            Password = password + Age + FirstName[0];
        }

        // Properties
        public string ManagerId { get => _managerId; set => _managerId = value; }
        public string Password { get => _password; set => _password = value; }
        public int Count { get => _count; set => _count = value; }

        // ToString Override
        public override string ToString()
        {
            return FirstName + LastName + "\n"
                   + ManagerId + "\n" +
                   Password;
        }

        // **------------------------- Methods -------------------------**

        //Password check
        public bool PasswordCheck()
        {
            Console.Write("PLEASE ENTER YOUR PASSWORD: ");
            String userInput = Console.ReadLine();
            if (Password.Trim().Equals(userInput.Trim()))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Password entered!!");
                return false;
            }

        }


        //Method to add instructor
        //Method to remove an instructor
        //Method to print list of instructors
        //Method to add a student, if need be
        //Method to delete a student
        //Search methods to look up instructors and students
        //Method to print out list of lessons days -- should vacant times and scheduled lessons
        //method to print info to a file.

    }
}
