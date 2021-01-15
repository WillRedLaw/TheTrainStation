using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainTimetable.Models
{
    public class StationDTO
    {
        public int StationId { get; set; }

        public string StationName { get; set; }
        public int TrainCount { get; set; }
        public bool NorthBound { get; set; }
        public bool SouthBound { get; set; }


        public List<StationDTO> stationDTOs { get; set; }
    }
}