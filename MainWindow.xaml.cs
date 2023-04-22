using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.VisualBasic;
namespace Gestion_horaire
{
    public partial class MainWindow : Window
    {
        public List<Employee> Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Employees = new List<Employee>();
            Employees.Add(new Employee("Mohamed Bakouche"));
            Employees.Add(new Employee("Yanis Bakouche"));
            Employees.Add(new Employee("Rihanna Celia Bakouche"));

            SelectUsersControl.Content = new SelectUsersWindow(Employees);
            ViewAvailabilityControl.Content = new ViewAvailabilityWindow();
            ScheduleResultsControl.Content = new ScheduleResultsWindow();
            CreateAppointmentControl.Content = new CreateAppointmentWindow(Employees);
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            string newUser = Interaction.InputBox("Veuillez entrer le nom du nouvel utilisateur", "Ajouter un utilisateur");
            if (!string.IsNullOrEmpty(newUser))
            {
                Employee newEmployee = new Employee(newUser);
                ((SelectUsersWindow)SelectUsersControl.Content).AddUser(newEmployee);
            }
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (((SelectUsersWindow)SelectUsersControl.Content).UsersDataGrid.SelectedItem != null)
            {
                Employee employeeToRemove = (Employee)((SelectUsersWindow)SelectUsersControl.Content).UsersDataGrid.SelectedItem;
                ((SelectUsersWindow)SelectUsersControl.Content).RemoveUser(employeeToRemove);
            }
        }

        private void FindAvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            ((SelectUsersWindow)SelectUsersControl.Content).CompareSelectedUsersAvailability();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le nom de l'employé et la disponibilité
            string employeeName = NameTextBox.Text;
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MinValue;
            TimeSpan startTime = TimeSpan.Parse(((ComboBoxItem)StartTimeComboBox.SelectedItem).Content.ToString());
            TimeSpan endTime = TimeSpan.Parse(((ComboBoxItem)EndTimeComboBox.SelectedItem).Content.ToString());
            // Créer un nouvel objet Availability avec les valeurs appropriées
            Availability availability = new Availability(startDate, endDate, startTime, endTime);

            // Ajouter l'employé et sa disponibilité
            Employee.AddEmployee(employeeName, availability, Employees);

            // Mettre à jour la liste d'utilisateurs et disponibilités
            ((SelectUsersWindow)SelectUsersControl.Content).UpdateUsers(Employees);
        }
    }
}
