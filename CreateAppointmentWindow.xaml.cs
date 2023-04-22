using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_horaire
{
    public partial class CreateAppointmentWindow : UserControl
    {
        private List<Employee> _employees;

        public CreateAppointmentWindow(List<Employee> employees)
        {
            InitializeComponent();
            _employees = employees;
        }

        private void SelectUsersButton_Click(object sender, RoutedEventArgs e)
        {
            SelectUsersWindow selectUsersWindow = new SelectUsersWindow(_employees);
            selectUsersWindow.AvailabilitySelected += SelectUsersWindow_AvailabilitySelected;
            ContentArea.Content = selectUsersWindow;
        }

        private void SelectUsersWindow_AvailabilitySelected(object sender, EventArgs e)
        {
            SelectUsersWindow selectUsersWindow = sender as SelectUsersWindow;
            if (selectUsersWindow != null)
            {
                SelectedUsersListBox.Items.Clear();
                foreach (Employee employee in selectUsersWindow.SelectedEmployees)
                {
                    SelectedUsersListBox.Items.Add(employee.Name);
                }
            }
        }

        private void CreateAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer la durée du rendez-vous
            int duration;
            if (!int.TryParse(DurationTextBox.Text, out duration))
            {
                MessageBox.Show("Veuillez entrer une durée valide (en minutes).", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Récupérer les utilisateurs sélectionnés
            List<Employee> selectedEmployees = new List<Employee>();
            foreach (string employeeName in SelectedUsersListBox.Items)
            {
                Employee employee = _employees.Find(emp => emp.Name == employeeName);
                if (employee != null)
                {
                    selectedEmployees.Add(employee);
                }
            }

            // Créer un nouvel objet rendez-vous avec les utilisateurs sélectionnés et la durée
            Appointment appointment = new Appointment(selectedEmployees, duration);

            // Créer une instance de la fenêtre de résultats de disponibilité et afficher les résultats
            ScheduleResultsWindow scheduleResultsWindow = new ScheduleResultsWindow();
            scheduleResultsWindow.ShowScheduleResults(appointment);
        }

    }
}
