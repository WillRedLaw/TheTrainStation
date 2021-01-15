using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainTimetable.Models
{
    public class PassengerDTO
    {

        public int PassengerId { get; set; }

        public string PassengerName { get; set; }
        public bool PreBookedTicket { get; set; }
        public int TicketPrice { get; set; }

        public List<PassengerDTO> passengerDTOs { get; set; }
    }
}