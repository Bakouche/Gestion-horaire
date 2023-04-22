using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;

namespace Gestion_horaire
{
    public partial class SelectUsersWindow : UserControl
    {
        public event EventHandler AvailabilitySelected;

        private List<Employee> _employees;
        public List<Employee> SelectedEmployees => GetSelectedUsers();

        public SelectUsersWindow() : this(null) { }

        public SelectUsersWindow(List<Employee> employees)
        {
            InitializeComponent();
            _employees = employees ?? new List<Employee>(Employee.EmployeeDictionary.Values);
            FillUsersListBox();
        }

        private string GetAvailabilityText(Employee employee)
        {
            if (employee.Availabilities.Count == 0)
            {
                return "Non défini";
            }

            List<string> availabilitiesText = new List<string>();
            foreach (Availability availability in employee.Availabilities)
            {
                string days = $"Du {availability.StartDate.ToShortDateString()} au {availability.EndDate.ToShortDateString()}";
                string hours = $"De {availability.StartTime} à {availability.EndTime}";
                availabilitiesText.Add($"{days}, {hours}");
            }

            return string.Join(" | ", availabilitiesText);
        }

        private void FillUsersListBox()
        {
            UsersDataGrid.Items.Clear();
            foreach (Employee employee in _employees)
            {
                UsersDataGrid.Items.Add(employee);
            }
        }

        public void AddUser(Employee newEmployee)
        {
            if (newEmployee != null)
            {
                _employees.Add(newEmployee);
                FillUsersListBox();
            }
        }

        public void RemoveUser(Employee employeeToRemove)
        {
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
                FillUsersListBox();
            }
        }

        public void UpdateUsers(List<Employee> updatedEmployees)
        {
            if (updatedEmployees != null)
            {
                _employees = updatedEmployees;
                FillUsersListBox();
            }
        }

        public List<Employee> CompareSelectedUsersAvailability()
        {
           
            return GetSelectedUsers();
        }

        public List<Employee> GetSelectedUsers()
        {
            List<Employee> selectedUsers = new List<Employee>();
            foreach (Employee employee in UsersDataGrid.SelectedItems)
            {
                selectedUsers.Add(employee);
            }
            return selectedUsers;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            string newUser = Interaction.InputBox("Veuillez entrer le nom du nouvel utilisateur", "Ajouter un utilisateur");
            if (!string.IsNullOrEmpty(newUser))
            {
                Employee newEmployee = new Employee(newUser);
                AddUser(newEmployee);
            }
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                Employee employeeToRemove = (Employee)UsersDataGrid.SelectedItem;
                RemoveUser(employeeToRemove);
            }
        }
    }
}
