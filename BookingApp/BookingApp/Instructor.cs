using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp
{
    class Instructor : Person
    {
        //member variables
        private string _concentration;
        private string _degree;
        private string _description;

        //properties
        public string Concentration { get => _concentration; set => _concentration = value; }
        public string Degree { get => _degree; set => _degree = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
