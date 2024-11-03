using System;
using System.Globalization;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
       DateTime time = DateTime.Parse(appointmentDateDescription, CultureInfo.InvariantCulture);
       return time;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        if(DateTime.Now > appointmentDate) { return true; }
        return false;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        TimeSpan noon = new TimeSpan(12, 0, 0);
        TimeSpan sixPm = new TimeSpan(18, 0 ,0);
        if(appointmentDate.TimeOfDay >= noon && appointmentDate.TimeOfDay < sixPm) { return true;}
        return false;
    }

    public static string Description(DateTime appointmentDate)
    {
        string description = "You have an appointment on " + appointmentDate.ToString("G") + ".";
        return description;
    }

    public static DateTime AnniversaryDate()
    {
        DateTime anniversary = new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
        return anniversary;
    }
}
