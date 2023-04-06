using System.Collections.Generic;
using System.Windows;

namespace Gestion_horaire
{
    public partial class ScheduleResultsWindow : Window
    {
        public ScheduleResultsWindow(Appointment appointment)
        {
            InitializeComponent();

            // Afficher les résultats de la recherche de disponibilité
            List<ScheduledTimeSlot> schedule = appointment.ScheduleMeeting();
            ScheduleListBox.ItemsSource = schedule;
        }
    }
}
