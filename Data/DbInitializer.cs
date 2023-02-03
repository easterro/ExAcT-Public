using ExtracurricularActivitiyLog.Models;
using System;
using System.Linq;

namespace ExtracurricularActivitiyLog.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            //Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstName="Carson",LastName="Alexander",StudentID=643526},
            new Student{FirstName="Meredith",LastName="Alonso",StudentID=643520},
            new Student{FirstName="Arturo",LastName="Anand",StudentID=643521},
            new Student{FirstName="Gytis",LastName="Barzdukas",StudentID=643522},
            new Student{FirstName="Yan",LastName="Li",StudentID=643523},
            new Student{FirstName="Peggy",LastName="Justice",StudentID=643524},
            new Student{FirstName="Laura",LastName="Norman",StudentID=643525},
            new Student{FirstName="Nino",LastName="Olivetto",StudentID=643527}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var clubs = new Club[]
            {
            new Club{ClubID=102916,Advisors="Cali Miller",Memberships=10, ClubName="Coding Club"},
            new Club{ClubID=102933,Advisors="Joshua Fender",Memberships=20,ClubName="Robotics Club"},
            new Club{ClubID=102897,Advisors="Julie Seddelmeyer",Memberships=219,ClubName="Student Admissions Organization (SAO)"},
            new Club{ClubID=102865,Advisors="Darryl Einhorn",Memberships=70,ClubName="Model United Nations"},
            
            };
            foreach (Club c in clubs)
            {
                context.Clubs.Add(c);
            }
            context.SaveChanges();

            var rosters = new Roster[]
            {
            new Roster{StudentID=1,ClubID=102916,Positions="President"},
            new Roster{StudentID=1,ClubID=102933,Positions="Vice President"},
            new Roster{StudentID=1,ClubID=102933,Positions="Member"},
            new Roster{StudentID=2,ClubID=102897,Positions="Member"},
            new Roster{StudentID=2,ClubID=102865,Positions="Member"},
            new Roster{StudentID=2,ClubID=102865,Positions="Member"},
            new Roster{StudentID=3,ClubID=102865,Positions="Member"},
            new Roster{StudentID=4,ClubID=102865,Positions="Member"},
            new Roster{StudentID=4,ClubID=102897,Positions="Member"},
            new Roster{StudentID=5,ClubID=102897,Positions="Member"},
            new Roster{StudentID=6,ClubID=102897,Positions="Member"},
            new Roster{StudentID=7,ClubID=102897,Positions="Member"},
            };
            foreach (Roster e in rosters)
            {
                context.Rosters.Add(e);
            }
            context.SaveChanges();
        }
    }
}
