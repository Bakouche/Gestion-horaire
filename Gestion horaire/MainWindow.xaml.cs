using System;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_horaire
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les valeurs entrées par l'utilisateur
            string name = NameTextBox.Text;
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MinValue;
            TimeSpan startTime = TimeSpan.Parse(((ComboBoxItem)StartTimeComboBox.SelectedItem).Content.ToString());
            TimeSpan endTime = TimeSpan.Parse(((ComboBoxItem)EndTimeComboBox.SelectedItem).Content.ToString());

            // Créer un nouvel objet Employee avec les valeurs entrées
            Employee employee = new Employee(name);
            Availability availability = new Availability(startDate, endDate, startTime, endTime);
            employee.Availabilities.Add(availability);

            // Ajouter l'objet Employee à une liste ou à une base de données
            // ...
        }
    }
}
