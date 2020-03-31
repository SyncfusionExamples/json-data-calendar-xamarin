using Newtonsoft.Json;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CalendarXamarin
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private CalendarEventCollection appointments;

        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarEventCollection Appointments
        {
            get
            {
                return this.appointments;
            }

            set
            {
                this.appointments = value;
                this.OnPropertyChanged("Appointments");
            }
        }

        //// Add data for JSON data model
        private string JsonData =
            "[{\"Subject\": \"General Meeting\",\"StartTime\": \"30 August 2018 02:00:00 PM\",\"EndTime\":\"30 August 2018 03:00:00 PM\",\"Background\":\"#5944dd\", \"IsAllDay\":\"True\"}, " +
            "{\"Subject\": \"Plan Execution\",\"StartTime\": \"22 August 2018 08:00:00 AM\",\"EndTime\":\"22 August 2018 10:00:00 AM\",\"Background\":\"#ff0000\", \"IsAllDay\":\"False\"}," +
            "{\"Subject\": \"Performance Check\",\"StartTime\": \"17 August 2018 05:00:00 PM\",\"EndTime\":\"17 August 2018 06:00:00 PM\",\"Background\":\"#5944dd\", \"IsAllDay\":\"False\"}," +
            "{\"Subject\": \"Consulting\",\"StartTime\": \"03 August 2018 09:00:00 AM\",\"EndTime\":\"03 August 2018 11:00:00 AM\",\"Background\":\"#ed0497\", \"IsAllDay\":\"True\"}," +
            "{\"Subject\": \"Yoga Therapy\",\"StartTime\": \"27 August 2018 09:00:00 AM\",\"EndTime\":\"27 August 2018 11:00:00 AM\",\"Background\":\"#ff0000\", \"IsAllDay\":\"False\"}," +
            "{\"Subject\": \"Project Plan\",\"StartTime\": \"30 August 2018 10:00:00 AM\",\"EndTime\":\"30 August 2018 11:00:00 AM\",\"Background\":\"#ed0497\", \"IsAllDay\":\"False\"} ]";

        public CalendarViewModel()
        {
            this.Appointments = new CalendarEventCollection();

            List<JSONData> jsonDataCollection = JsonConvert.DeserializeObject<List<JSONData>>(JsonData);

            foreach (var data in jsonDataCollection)
            {
                this.Appointments.Add(new CalendarInlineEvent()
                {
                    Subject = data.Subject,
                    StartTime = Convert.ToDateTime(data.StartTime),
                    EndTime = Convert.ToDateTime(data.EndTime),
                    Color = Color.FromHex(data.Background),
                    IsAllDay = Convert.ToBoolean(data.IsAllDay)
                });
            }
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}