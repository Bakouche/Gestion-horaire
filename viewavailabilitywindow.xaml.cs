using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_horaire
{
    public partial class ViewAvailabilityWindow : UserControl
    {
        public List<User> Users { get; set; }

        public ViewAvailabilityWindow()
        {
            InitializeComponent();
            Users = new List<User>();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            foreach (User user in Users)
            {
                UserList.Items.Add(user.Name);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class TimeSlotPlanner
    {
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public TimeSlotPlanner(DateTime startTime, int duration)
        {
            StartTime = startTime;
            Duration = duration;
        }

        public List<ScheduledTimeSlot> PlanTimeSlots()
        {
            List<ScheduledTimeSlot> scheduledTimeSlots = new List<ScheduledTimeSlot>();

            DateTime currentTime = StartTime;
            for (int i = 0; i < 10; i++)
            {
                DateTime endTime = currentTime.AddMinutes(Duration);
                scheduledTimeSlots.Add(new ScheduledTimeSlot(currentTime, endTime));
                currentTime = endTime;
            }

            return scheduledTimeSlots;
        }
    }

    public class ScheduledTimeSlot
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public ScheduledTimeSlot(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public List<ScheduledTimeSlot> Availability { get; set; }

        public User(string name, List<ScheduledTimeSlot> availability)
        {
            Name = name;
            Availability = availability;
        }
    }
}
