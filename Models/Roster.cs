using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtracurricularActivitiyLog.Models
{
    public class Roster
    {
            public int RosterID { get; set; }
            public int ClubID { get; set; }
            public int StudentID { get; set; }
            public Student Students { get; set; }
            
            public string Positions { get; set; }

            public Club Clubs { get; set; }
            
    }
}
