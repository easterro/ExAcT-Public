using System;
using System.Collections.Generic;

namespace ExtracurricularActivitiyLog.Models
{
    public class Student
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ICollection<Roster> Rosters { get; set; }
    }
}
