using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp
{
    class Person
    {
        //Member variables
        private string _firstName;
        private string _lastName;
        private int _age;

        //properties
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Age { get => _age; set => _age = value; }
    }
}
