using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainTimetable.Models
{
    public class Train
    {
        public Train()
        {
            this.Stations = new List<Station>();
            this.Passengers = new List<Passenger>();
        }

        //ID
        public int TrainiD { get; set; }

        //Train Information
        public string TrainName { get; set; }
        public int TrainNumber { get; set; }
        public int TrainCapcity { get; set; }
        public Boolean TrainRunningToday { get; set; } = false;


        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Station> Stations { get; set; }

    }
}