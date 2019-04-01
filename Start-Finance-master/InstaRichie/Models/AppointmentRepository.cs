using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite.Net;

namespace StartFinance.Models
{
    public class AppointmentRepository : IAppointmentRepository
    {
        string path;
        SQLiteConnection conn;

        public AppointmentRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbName);
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Appointment>();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return conn.Table<Appointment>().ToList();
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            var appointments = conn.Table<Appointment>().ToList();
            return appointments.First(p => p.AppointmentId == appointmentId);
        }

        public bool InsertAppointment(Appointment appointment)
        {
            if (conn.Insert(appointment) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteAppointment(int appointmentId)
        {
            Appointment a = GetAppointmentById(appointmentId);
            if (conn.Delete(a) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            if (conn.Update(appointment) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Appointment> FindAppointment(int id, string EventName)
        {
            var appointments = conn.Table<Appointment>().ToList();
            if(id != 0)
            {
                return appointments.FindAll(a => a.AppointmentId == id);
            }
            else
            {
                return appointments.FindAll(a => a.EventName == EventName);
            }

        }

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}
