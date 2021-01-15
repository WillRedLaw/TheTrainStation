using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainTimetable.Models
{
    public class TimetableDTO
    {

        public int TimetableDTOId { get; set; }

        public string TimetableDay { get; set; }
        public int TimetableArrival { get; set; }
        public int TimeDeparture { get; set; }
        
        public List<TimetableDTO> timetableDTOs { get; set; }

    }
}