using System.Collections.Generic;
using System.Windows;

namespace Gestion_horaire
{
    public partial class CreateAppointmentWindow : Window
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
            selectUsersWindow.ShowDialog();

            // Ajouter les utilisateurs sélectionnés à la liste
            if (selectUsersWindow.DialogResult.HasValue && selectUsersWindow.DialogResult.Value)
            {
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

            // Ouvrir la fenêtre de résultats de disponibilité
            ScheduleResultsWindow scheduleResultsWindow = new ScheduleResultsWindow(appointment);
            scheduleResultsWindow.ShowDialog();
        }
    }
}
