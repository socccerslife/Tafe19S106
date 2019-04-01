using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointmentById(int appointmentId);
        bool InsertAppointment(Appointment appointment);
        bool DeleteAppointment(int appointmentId);
        bool UpdateAppointment(Appointment appointment);
        IEnumerable<Appointment> FindAppointment(int id, string EventName);
        void Save();
    }
}
