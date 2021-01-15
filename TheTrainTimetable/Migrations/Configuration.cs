namespace TheTrainTimetable.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using TheTrainTimetable.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheTrainTimetable.Models.TheTrainTimetableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheTrainTimetable.Models.TheTrainTimetableContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed 

            var trains = new List<Train>
            {

                new Train {TrainName = "Boston", TrainNumber = 1, TrainCapcity = 50, TrainRunningToday = true},
                new Train {TrainName = "New York City", TrainNumber = 2, TrainCapcity = 100, TrainRunningToday = false },
                new Train {TrainName = "Connonly", TrainNumber = 45, TrainCapcity = 30, TrainRunningToday = false }

            };

            trains.ForEach(T => context.trains.AddOrUpdate(train => train.TrainName, T));
            context.SaveChanges();

            var passengers = new List<Passenger>
            {
                new Passenger{PassengerName = "Mary", PreBookedTicket = true, TicketPrice = 20},
                new Passenger{PassengerName = "Sean", PreBookedTicket = false, TicketPrice = 15},
                new Passenger{PassengerName = "Cathal", PreBookedTicket = false, TicketPrice = 15}
            };

            passengers.ForEach(P => context.passengers.AddOrUpdate(Passenger => Passenger.PassengerName, P));
            context.SaveChanges();

            var stations = new List<Station>
            {
                new Station{ StationName = "Connonly Station", NorthBound = true, SouthBound = true, TrainCount = 60},
                new Station{StationName = "New York Central Station", NorthBound = true, SouthBound = true, TrainCount = 100},
                new Station{StationName = "Wexford Station", NorthBound = true, SouthBound = false, TrainCount = 2}
            };
            stations.ForEach(S => context.stations.AddOrUpdate(Station => Station.StationName, S));
            context.SaveChanges();

        }

      
    }
}
