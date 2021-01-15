using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TheTrainTimetable.Models
{
    public class TrainDTO
    {

        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public int TrainNumber { get; set; }
        public int TrainCapcity { get; set; }
        public bool IsTrainRunningToday { get; set; }

        public List<TrainDTO> trainDTOs { get; set; }
    }
}