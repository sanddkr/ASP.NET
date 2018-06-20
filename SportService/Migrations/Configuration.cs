namespace SportService.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportService.Models.SportServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportService.Models.SportServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Teams.AddOrUpdate(x => x.type_of_sport,
               new Team() { type_of_sport = "basketball", coach_name = "Vincent Huck", season = "S", fee = 235 },
               new Team() { type_of_sport = "softball", coach_name = "James Butt", season = "B", fee = 220 },
               new Team() { type_of_sport = "football", coach_name = "Josephine Darakjy", season = "B", fee = 135 },
               new Team() { type_of_sport = "hockey", coach_name = "Art Venere", season = "S", fee = 335 },
               new Team() { type_of_sport = "netball", coach_name = "Lenna Paprocki", season = "F", fee = 300 }
               );

            context.Athletes.AddOrUpdate(x => x.student_number,
               new Athlete() { student_number = "12310000", student_firstname = "Kris", student_lastname = "Marrier", type_of_sport= "basketball", birthday= new DateTime(1997,10,10), height = Decimal.Parse("1.75") },
               new Athlete() { student_number = "12310100", student_firstname = "Minna", student_lastname = "Amigon", type_of_sport = "basketball", birthday = new DateTime(1995, 1, 20), height = Decimal.Parse("1.65") },
               new Athlete() { student_number = "12310200", student_firstname = "Abel", student_lastname = "Maclead", type_of_sport = "basketball", birthday = new DateTime(1990, 12, 3), height = Decimal.Parse("1.67") },
               new Athlete() { student_number = "12310300", student_firstname = "Kiley", student_lastname = "Caldarera", type_of_sport = "basketball", birthday = new DateTime(1990, 8, 22), height = Decimal.Parse("1.68") },
               new Athlete() { student_number = "12311100", student_firstname = "Graciela", student_lastname = "Ruta", type_of_sport = "softball", birthday = new DateTime(1995, 5, 16), height = Decimal.Parse("1.68") },
               new Athlete() { student_number = "12311200", student_firstname = "Cammy", student_lastname = "Albares", type_of_sport = "softball", birthday = new DateTime(2000, 5, 8), height = Decimal.Parse("1.64") },
               new Athlete() { student_number = "12311300", student_firstname = "Mattie", student_lastname = "Poquette", type_of_sport = "softball", birthday = new DateTime(1998, 7, 23), height = Decimal.Parse("1.75") },
               new Athlete() { student_number = "12311400", student_firstname = "Meaghan", student_lastname = "Garufi", type_of_sport = "softball", birthday = new DateTime(1997, 1, 21), height = Decimal.Parse("1.73") },
               new Athlete() { student_number = "12312100", student_firstname = "Gladys", student_lastname = "Rim", type_of_sport = "football", birthday = new DateTime(1990, 9, 9), height = Decimal.Parse("1.74") },
               new Athlete() { student_number = "12312200", student_firstname = "Yuki", student_lastname = "Whobrey", type_of_sport = "football", birthday = new DateTime(1991, 6, 5), height = Decimal.Parse("1.80") },
               new Athlete() { student_number = "12312300", student_firstname = "Fletcher", student_lastname = "Flosi", type_of_sport = "football", birthday = new DateTime(1989, 12, 20), height = Decimal.Parse("1.70") },
               new Athlete() { student_number = "12312400", student_firstname = "Bette", student_lastname = "Nicka", type_of_sport = "football", birthday = new DateTime(1988, 11, 18), height = Decimal.Parse("1.77") },
               new Athlete() { student_number = "12313100", student_firstname = "Veronika", student_lastname = "Inouye", type_of_sport = "hockey", birthday = new DateTime(1994, 6, 9), height = Decimal.Parse("1.78") },
               new Athlete() { student_number = "12313200", student_firstname = "Willard", student_lastname = "Kolmetz", type_of_sport = "hockey", birthday = new DateTime(1996, 8, 5), height = Decimal.Parse("1.72") },
               new Athlete() { student_number = "12313300", student_firstname = "Maryann", student_lastname = "Royster", type_of_sport = "hockey", birthday = new DateTime(1988, 6, 25), height = Decimal.Parse("1.68") },
               new Athlete() { student_number = "12313400", student_firstname = "Alisha", student_lastname = "Slusarski", type_of_sport = "hockey", birthday = new DateTime(1989, 10, 3), height = Decimal.Parse("1.69") },
               new Athlete() { student_number = "12314100", student_firstname = "Allene", student_lastname = "Iturbide", type_of_sport = "netball", birthday = new DateTime(1991, 6, 7), height = Decimal.Parse("1.70") },
               new Athlete() { student_number = "12314200", student_firstname = "Chanel", student_lastname = "Caudy", type_of_sport = "netball", birthday = new DateTime(1992, 2, 1), height = Decimal.Parse("1.75") },
               new Athlete() { student_number = "12314300", student_firstname = "Ezekiel", student_lastname = "Chui", type_of_sport = "netball", birthday = new DateTime(1994, 4, 12), height = Decimal.Parse("1.78") },
               new Athlete() { student_number = "12314400", student_firstname = "Willow", student_lastname = "Kusko", type_of_sport = "netball", birthday = new DateTime(1986, 3, 27), height = Decimal.Parse("1.82") }

               );

        }
    }
}
