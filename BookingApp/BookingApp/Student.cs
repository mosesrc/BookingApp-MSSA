using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp
{
    class Student : Person
    {
        private string _instrument;
        private string _tableName = "students";
        private int _studentId;

        public string Instrument { get => _instrument; set => _instrument = value; }
        public string TableName { get => _tableName; set => _tableName = value; }
        public int StudentId { get => _studentId; set => _studentId = value; }
    }
}
