using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainTimetable.Models
{
    public class Timetable
    {

        private ICollection<Station> _stations;

        //Timetable ID
        public int TimetableiD { get; set; }
        //Timetable information
        public string TimetableDay { get; set; }
        public int TimetableArrival { get; set; }
        public int TimetableDepart { get; set; }

        public virtual List<Station> Stations
        {
            get { return _stations.ToList(); }
            set { _stations = value; }
        }

        public Timetable()
        {
            this.Stations = new List<Station>();

        }
    }
}
