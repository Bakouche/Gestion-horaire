using System;
using System.Collections.Generic;

namespace Gestion_horaire
{
    public class Employee
    {
        public string Name { get; set; }
        public List<Availability> Availabilities { get; set; }
        public string AvailabilityText => GetAvailabilityText();

        public Employee(string name)
        {
            Name = name;
            Availabilities = new List<Availability>();
        }

        public Employee(string name, Availability availability) : this(name)
        {
            Availabilities.Add(availability);
        }

        public string GetAvailabilityText()
        {
            if (Availabilities.Count == 0)
            {
                return "Non défini";
            }

           
            List<string> availabilitiesText = new List<string>();
            foreach (Availability availability in Availabilities)
            {
                string days = $"Du {availability.StartDate.ToShortDateString()} au {availability.EndDate.ToShortDateString()}";
                string hours = $"De {availability.StartTime} à {availability.EndTime}";
                availabilitiesText.Add($"{days}, {hours}");
            }

            return string.Join(" | ", availabilitiesText);
        }

        public static Dictionary<string, Employee> EmployeeDictionary = new Dictionary<string, Employee>();

        public static void AddEmployee(string name, Availability availability)
        {
            if (EmployeeDictionary.ContainsKey(name))
            {
                EmployeeDictionary[name].Availabilities.Add(availability);
            }
            else
            {
                Employee newEmployee = new Employee(name, availability);
                EmployeeDictionary.Add(name, newEmployee);
            }
        }

        public static Employee AddEmployee(string name, Availability availability, List<Employee> employeeList)
        {
            Employee employee;
            if (EmployeeDictionary.ContainsKey(name))
            {
                employee = EmployeeDictionary[name];
                employee.Availabilities.Add(availability);
            }
            else
            {
                employee = new Employee(name, availability);
                EmployeeDictionary.Add(name, employee);
                employeeList.Add(employee);
            }

            return employee;
        }

        public static List<ScheduledTimeSlot> GetCommonAvailability(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                return new List<ScheduledTimeSlot>();
            }

           
            return null;
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
