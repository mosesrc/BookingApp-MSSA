using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp
{
    class Calendar
    {

        String[] month = { "Febraury", "March", "April" };
        String[] Week = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        DateTime date1 = new DateTime(2022, 1, 1);
        DateTime date2 = new DateTime(2022, 3, 31);
        List<DateTime> calendarOne = new List<DateTime>();

        public List<DateTime> CalendarOne { get => calendarOne; set => calendarOne = value; }

        public DateTime[] JanToMarCalendar()
        {
                for (DateTime day = date1; day <= date2; day = day.AddDays(1))
            {
                CalendarOne.Add(day);
                Console.WriteLine(day);
            }
            return CalendarOne.ToArray();
        }
    }
}
