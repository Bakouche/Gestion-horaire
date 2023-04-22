using System;

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
