using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp
{
    class Lessons
    {
        // member variables
        private int _month;
        private int _year;
        private int _day;
        private string[] _instruments = { "Piano", "Trumpet", "Percussion", "Bass", "Guitar" };

        //member properties
        public int Month { get => _month; set => _month = value; }
        public int Year { get => _year; set => _year = value; }
        public int Day { get => _day; set => _day = value; }
        public string[] Instruments { get => _instruments; set => _instruments = value; }

        public void BookALesson ()
        {   
            Console.WriteLine("Hello, Would you like to book a lesson with one of our teacher's? (yes / no");

            Console.WriteLine("What would you like to learn? we offer: ");
            // Spacing out Lesson Topics
            for (int i = 0; i <= Instruments.Length; i++)
            {
                Console.WriteLine(String.Join("  |  ", Instruments[i].PadLeft(10)));
            }

            Console.WriteLine("Your preferred days of week are?");

            Console.WriteLine("You're preferred time: ");
        }


    }


}
