using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.ComponentModel;
using System.Collections.ObjectModel;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    public class AppointmentViewModel : INotifyPropertyChanged
    {
        private IAppointmentRepository Db { get; }
        private ObservableCollection<Appointment> appointments;

        public ObservableCollection<Appointment> Appointments
        {
            get { return appointments; }
            set
            {
                if (value != appointments)
                {
                    appointments = value;
                    NotifyPropertyChanged("Appointments");
                }
            }
        }

        public AppointmentViewModel()
        {
            Db = App.Data2;
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            Appointments = new ObservableCollection<Appointment>(Db.GetAppointments().ToList());
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal async void AddNewAppointment(Appointment newAppointment)
        {
            if (Db.InsertAppointment(newAppointment))
            {
                MessageDialog md = new MessageDialog("New Appointment added to schedule", "NEW APPOINTMENT ADDED");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Appointment is fail to added to schedule", "FAIL TO ADD APPOINTMENT");
                await md.ShowAsync();
            }
        }

    }
}
