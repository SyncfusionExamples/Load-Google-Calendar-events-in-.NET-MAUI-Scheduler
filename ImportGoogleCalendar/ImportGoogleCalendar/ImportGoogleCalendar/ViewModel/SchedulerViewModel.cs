using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ImportGoogleCalendar
{
    public class SchedulerViewModel 
    {
        /// <summary>
        /// Gets or sets scheduler appointments.
        /// </summary>
        public ObservableCollection<Appointment> Appointments { get; set; } = new ObservableCollection<Appointment>();

        public SchedulerViewModel()
        {
            // Initialize the Google Calendar Service with the API key 
            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                ApiKey = "Use the API key of your created project",
                ApplicationName = "Use the name of your created project"
            });

            string calendarId = "Use Google Calendar Id";

            // Define a DateTime range to retrieve events
            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now.AddDays(90);

            // Define the request to retrieve events
            EventsResource.ListRequest request = service.Events.List(calendarId);
            request.TimeMin = startDate;
            request.TimeMax = endDate;
            request.ShowDeleted = false;

            // Execute the calendar service request and retrieve events
            Events events = request.Execute();
            foreach (Event appointment in events.Items)
            {
                Appointments.Add(new Appointment()
                {
                    EventName = appointment.Summary,
                    From = Convert.ToDateTime(appointment.Start.Date),
                    To = Convert.ToDateTime(appointment.End.Date),
                    Background = Color.FromArgb("#FF3F51B5")
                });
            }
        }
    }
}
