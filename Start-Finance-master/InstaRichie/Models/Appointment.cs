using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace StartFinance.Models
{
    public class Appointment
    {
        [PrimaryKey AutoIncrement]
        public int AppointmentId { get; private set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public string EventDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
