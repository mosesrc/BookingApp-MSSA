using System;
using System.Collections;
using System.Text;

namespace BookingApp
{
    class Manager : Person
    {
        //Member variables
        private string _managerId;
        private string _password;
        private int _count = 1;
        private ArrayList instructorsList = new ArrayList();


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
        public ArrayList InstructorsList { get => instructorsList; set => instructorsList = value; }

        // ToString Override
        public override string ToString()
        {
            return "\n*-- Manager --* \n" + FirstName + " " + LastName + "\n"
                   + "Manager ID: " + ManagerId + "\n" +
                   "Password: " + Password +"\n";
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

        public int ManagerMenu()
        {
            int userInput;

            // Manager's Menu
            Console.WriteLine("\n1) Add an Instructor\n");
            Console.WriteLine("\n2) Remove an Instructor\n");
            Console.WriteLine("\n3) Add a Student Account\n");
            Console.WriteLine("\n4) Delete a Student Account\n");
            Console.WriteLine("\n5) Search for an Instructor\n");
            Console.WriteLine("\n6) Search for a Student\n");
            Console.WriteLine("\n7) Print out list of Instructors\n");
            Console.WriteLine("\n8) Print out list of Students\n");
            Console.WriteLine("\n9) Print out Lesson Calendar\n");
            Console.WriteLine("\n10) Print out Database Information to File\n");

            Console.Write("Please enter a number: ");
            userInput = Int32.Parse(Console.ReadLine());

            return userInput;


        }

        // TODO: TASK 1A -- Method to add instructor
        public void AddInstructor(DataSource std)
        {
            string fName;
            string lName;
            int age;
            string instrum;
            string desc;
            string degree;

            Console.Write("\nPlease enter Instructor's First Name: ");
            fName = Console.ReadLine().Trim();

            Console.Write("\nPlease enter Instructor's Last Name: ");
            lName = Console.ReadLine().Trim();

            Console.Write("\n Please enter Instructor's Age: ");
            age = Int32.Parse(Console.ReadLine().Trim());

            Console.Write("\nPlease enter Instructor's Intrument: ");
            instrum = Console.ReadLine().Trim();

            Console.Write("\nPlease enter Instructor's Degree: ");
            degree = Console.ReadLine().Trim();

            Console.WriteLine("\nGive Instructor a Brief Description: ");
            desc = Console.ReadLine().Trim();

            std.Insert(new Instructor(fName, lName, age, instrum, degree, desc));
            InstructorsList.Add(new Instructor(fName, lName, age, instrum, degree, desc));
        }
        // TODO: TASK 1B -- Method to remove an instructor
        public void RemoveInstructor(DataSource std, Instructor instructor)
        {
            Console.WriteLine();
            std.Delete(instructor);
        }

        // TODO: TASK 1C --Method to print list of instructors
        public void PrintInstructorList()
        {

        }

        // TODO: TASK 2A -- Method to add a student
        public void AddStudent()
        {

        }

        // TODO: TASK 2B -- Method to delete a student
        public void RemoveStudent(DataSource std, Student student)
        {
            Console.WriteLine();
            std.Delete(student);
        }

        // TODO: TASK 4A -- Search methods to look up instructors 
        public void SearchInstructors()
        {
            
        }

        // TODO: TASK 4B -- Search methods to look up students
        public void SearchStudents()
        {

        }
        
        // TODO: TASK 5A -- Method to print out list of lessons days -- should vacant times and scheduled lessons
        public void PrintCalendar()
        {

        }

        // TODO: TASK 5B -- Method to print info to a file.
        public void PrintToFile()
        {

        }

    }
}
