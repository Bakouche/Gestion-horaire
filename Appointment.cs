using System;
using System.Collections.Generic;

namespace Gestion_horaire
{
    public class Appointment
    {
        public List<Employee> Employees { get; set; }
        public int Duration { get; set; }

        public Appointment(List<Employee> employees, int duration)
        {
            Employees = employees;
            Duration = duration;
        }

        public List<ScheduledTimeSlot> ScheduleMeeting()
        {
         
            List<ScheduledTimeSlot> scheduledTimeSlots = new List<ScheduledTimeSlot>();

           
            return scheduledTimeSlots;
        }
    }
}
