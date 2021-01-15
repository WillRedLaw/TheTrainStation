using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainTimetable.Models
{
    public class Passenger
    {
        public Passenger()
        {
            this.Stations = new List<Station>();
            this.Trains = new List<Train>();
        }

        public int PassengeriD { get; set; }

        public string PassengerName { get; set; }
        public bool PreBookedTicket { get; set; } = false;
        public int TicketPrice { get; set; }

        public virtual ICollection<Station> Stations { get; set; }
        public virtual ICollection<Train> Trains { get; set; }
    }
}