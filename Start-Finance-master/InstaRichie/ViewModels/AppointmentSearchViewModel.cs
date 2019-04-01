using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    public class AppointmentSearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IAppointmentRepository Db { get; }
        private ObservableCollection<Appointment> appointment;
        
        public ObservableCollection<Appointment> Appointments
        {
            get { return appointment; }
            set
            {
                if (value != appointment)
                {
                    appointment = value;
                    NotifyPropertyChanged("Appointments");
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public AppointmentSearchViewModel()
        {
            Db = App.Data2;
        }

        public IEnumerable<Appointment> FindAppointment(int id, string eventName)
        {
            return (Db.FindAppointment(id, eventName));
        }
    }
}
