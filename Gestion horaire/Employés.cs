using System;
using System.Collections.Generic;

namespace Gestion_horaire
{
    public class Employee
    {
        public string Name { get; set; }
        public List<Availability> Availabilities { get; set; }

        public Employee(string name)
        {
            Name = name;
            Availabilities = new List<Availability>();
        }
    }

    public class Availability
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Availability(DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime)
        {
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
