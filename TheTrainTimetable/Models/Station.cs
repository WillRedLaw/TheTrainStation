using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainTimetable.Models
{
    public class Station
    {

        public Station()
        {
            this.Trains = new List<Train>();
        }

        //Station ID
        public int StationiD { get; set; }

        //Station Information
        public string StationName { get; set; }
        public int TrainCount { get; set; }
        public Boolean NorthBound { get; set; } = false;
        public Boolean SouthBound { get; set; } = false;

        public virtual ICollection<Train> Trains { get; set; }
    }
}