using System;

public class ScheduledTimeSlot
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public ScheduledTimeSlot(DateTime startTime, int duration)
    {
        StartTime = startTime;
        EndTime = startTime.AddMinutes(duration);
    }
}
