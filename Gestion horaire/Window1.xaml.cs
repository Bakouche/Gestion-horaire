using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_horaire
{
    public partial class SelectUsersWindow : Window
    {
        public List<Employee> SelectedEmployees { get; private set; }

        private List<Employee> _employees;

        public SelectUsersWindow(List<Employee> employees)
        {
            InitializeComponent();
            _employees = employees;
        }

        private void FindAvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer la durée de la rencontre
            int duration;
            switch (DurationComboBox.SelectedIndex)
            {
                case 0:
                    duration = 30;
                    break;
                case 1:
                    duration = 60;
                    break;
                case 2:
                    duration = 90;
                    break;
                case 3:
                    duration = 120;
                    break;
                default:
                    duration = 0;
                    break;
            }

            // Récupérer les utilisateurs sélectionnés
            SelectedEmployees = new List<Employee>();
            foreach (object selectedItem in UsersListBox.SelectedItems)
            {
                ListBoxItem listBoxItem = (ListBoxItem)selectedItem;
                Employee employee = _employees.Find(emp => emp.Name == listBoxItem.Content.ToString());
                if (employee != null)
                {
                    SelectedEmployees.Add(employee);
                }
            }

            if (SelectedEmployees.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner au moins un utilisateur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (duration == 0)
            {
                MessageBox.Show("Veuillez sélectionner une durée de rencontre valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
