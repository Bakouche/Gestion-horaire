using System.Collections.Generic;
using System.Windows;

namespace Gestion_horaire
{
    public partial class ViewAvailabilityWindow : Window
    {
        public string UserName { get; set; }
        public List<ScheduledTimeSlot> Availability { get; set; }

        public ViewAvailabilityWindow(string userName, List<ScheduledTimeSlot> availability)
        {
            InitializeComponent();

            UserName = userName;
            Availability = availability;
            DataContext = this;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
