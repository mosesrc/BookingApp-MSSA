using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp
{
    class Instructor : Person
    {
        //member variables
        private string _degree;
        private string _description;
        private string _instrument;
        private string _tableName = "instructors";
        private int _InstructorId;

        public Instructor(string fName, string lName, int age, string instrum, string degree, string desc)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
            Degree = degree;
            Description = desc;
            Instrument = instrum;
        }

        //properties
        public string Degree { get => _degree; set => _degree = value; }
        public string Description { get => _description; set => _description = value; }
        public string Instrument { get => _instrument; set => _instrument = value; }
        public string TableName { get => _tableName; set => _tableName = value; }
        public int InstructorId { get => _InstructorId; set => _InstructorId = value; }
    }
}
