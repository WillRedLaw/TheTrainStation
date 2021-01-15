namespace TheTrainTimetable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        PassengeriD = c.Int(nullable: false, identity: true),
                        PassengerName = c.String(),
                        PreBookedTicket = c.Boolean(nullable: false),
                        TicketPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PassengeriD);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationiD = c.Int(nullable: false, identity: true),
                        StationName = c.String(),
                        TrainCount = c.Int(nullable: false),
                        NorthBound = c.Boolean(nullable: false),
                        SouthBound = c.Boolean(nullable: false),
                        Passenger_PassengeriD = c.Int(),
                        Timetable_TimetableiD = c.Int(),
                    })
                .PrimaryKey(t => t.StationiD)
                .ForeignKey("dbo.Passengers", t => t.Passenger_PassengeriD)
                .ForeignKey("dbo.Timetables", t => t.Timetable_TimetableiD)
                .Index(t => t.Passenger_PassengeriD)
                .Index(t => t.Timetable_TimetableiD);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        TrainiD = c.Int(nullable: false, identity: true),
                        TrainName = c.String(),
                        TrainNumber = c.Int(nullable: false),
                        TrainCapcity = c.Int(nullable: false),
                        TrainRunningToday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrainiD);
            
            CreateTable(
                "dbo.Timetables",
                c => new
                    {
                        TimetableiD = c.Int(nullable: false, identity: true),
                        TimetableDay = c.String(),
                        TimetableArrival = c.Int(nullable: false),
                        TimetableDepart = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimetableiD);
            
            CreateTable(
                "dbo.TrainPassengers",
                c => new
                    {
                        Train_TrainiD = c.Int(nullable: false),
                        Passenger_PassengeriD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Train_TrainiD, t.Passenger_PassengeriD })
                .ForeignKey("dbo.Trains", t => t.Train_TrainiD, cascadeDelete: true)
                .ForeignKey("dbo.Passengers", t => t.Passenger_PassengeriD, cascadeDelete: true)
                .Index(t => t.Train_TrainiD)
                .Index(t => t.Passenger_PassengeriD);
            
            CreateTable(
                "dbo.TrainStations",
                c => new
                    {
                        Train_TrainiD = c.Int(nullable: false),
                        Station_StationiD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Train_TrainiD, t.Station_StationiD })
                .ForeignKey("dbo.Trains", t => t.Train_TrainiD, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.Station_StationiD, cascadeDelete: true)
                .Index(t => t.Train_TrainiD)
                .Index(t => t.Station_StationiD);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stations", "Timetable_TimetableiD", "dbo.Timetables");
            DropForeignKey("dbo.Stations", "Passenger_PassengeriD", "dbo.Passengers");
            DropForeignKey("dbo.TrainStations", "Station_StationiD", "dbo.Stations");
            DropForeignKey("dbo.TrainStations", "Train_TrainiD", "dbo.Trains");
            DropForeignKey("dbo.TrainPassengers", "Passenger_PassengeriD", "dbo.Passengers");
            DropForeignKey("dbo.TrainPassengers", "Train_TrainiD", "dbo.Trains");
            DropIndex("dbo.TrainStations", new[] { "Station_StationiD" });
            DropIndex("dbo.TrainStations", new[] { "Train_TrainiD" });
            DropIndex("dbo.TrainPassengers", new[] { "Passenger_PassengeriD" });
            DropIndex("dbo.TrainPassengers", new[] { "Train_TrainiD" });
            DropIndex("dbo.Stations", new[] { "Timetable_TimetableiD" });
            DropIndex("dbo.Stations", new[] { "Passenger_PassengeriD" });
            DropTable("dbo.TrainStations");
            DropTable("dbo.TrainPassengers");
            DropTable("dbo.Timetables");
            DropTable("dbo.Trains");
            DropTable("dbo.Stations");
            DropTable("dbo.Passengers");
        }
    }
}
