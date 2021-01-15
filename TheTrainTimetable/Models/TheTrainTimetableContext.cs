using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TheTrainTimetable.Models
{
    public class TheTrainTimetableContext : DbContext
    {

        public TheTrainTimetableContext() : base("TheTrainTimetableContext") { }

        public DbSet<Timetable> timetables { get; set; }
        public DbSet<Station> stations { get; set; }
        public DbSet<Train> trains { get; set; }
        public DbSet<Passenger> passengers { get; set; }

    }
}