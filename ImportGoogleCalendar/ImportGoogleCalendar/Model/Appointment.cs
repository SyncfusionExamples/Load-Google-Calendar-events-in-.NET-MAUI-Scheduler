using System.ComponentModel;

namespace ImportGoogleCalendar
{
    public class Appointment : INotifyPropertyChanged
    {
        private DateTime from , to;
        private string eventName;

        /// <summary>
        /// Gets or sets the value to display the start date.
        /// </summary>
        public DateTime From
        {
            get
            { return this.from; }
            set
            {
                this.from = value;
                this.OnPropertyChanged(nameof(From));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the end date.
        /// </summary>
        public DateTime To
        {
            get { return this.to; }
            set
            {
                this.to = value;
                this.OnPropertyChanged(nameof(To));
            }
        }

        /// <summary>
        /// Gets or sets the value to display the subject.
        /// </summary>
        public string EventName
        {
            get { return this.eventName; }
            set { this.eventName = value; }
        }

        /// <summary>
        /// Gets or sets the appointment background color.
        /// </summary>
        public Brush Background { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
