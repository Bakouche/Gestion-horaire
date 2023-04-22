using System.Collections.Generic;
using System.Windows.Controls;

namespace Gestion_horaire
{
    public partial class ScheduleResultsWindow : UserControl
    {
        public ScheduleResultsWindow()
        {
            InitializeComponent();
        }

        public void ShowScheduleResults(Appointment appointment)
        {
            List<ScheduledTimeSlot> schedule = appointment.ScheduleMeeting();
            ScheduleListBox.ItemsSource = schedule;
        }

        public void DisplayCommonAvailability(List<ScheduledTimeSlot> commonAvailability)
        {
            ScheduleListBox.ItemsSource = commonAvailability;
        }
    }
}
