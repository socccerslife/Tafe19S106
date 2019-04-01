using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    public class AppointmentDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IAppointmentRepository Db { get; }
        private Appointment appointment;

        public Appointment Appointment
        {
            get { return appointment; }
            set
            {
                if (appointment != value)
                {
                    appointment = value;
                    RaisePropertyChanged("Appointment");
                }
            }
        }

        private void RaisePropertyChanged(string propname)
        {
            var eh = PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propname));
        }

        public AppointmentDetailViewModel(int appointmentId)
        {
            Db = App.Data2;
            this.Appointment = Db.GetAppointmentById(appointmentId);
        }

        public AppointmentDetailViewModel()
        {
            Db = App.Data2;
        }

        public bool SaveEditedAppointment(Appointment a)
        {
            return Db.UpdateAppointment(a);
        }

        public bool DeleteAppointment(int appointmentId)
        {
            return Db.DeleteAppointment(appointmentId);
        }

    }
}
