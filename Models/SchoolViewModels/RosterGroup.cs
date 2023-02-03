using System;
using System.ComponentModel.DataAnnotations;

namespace ExtracurricularActivitiyLog.Models.SchoolViewModels
{
    public class RosterGroup
    {
        [DataType(DataType.Date)]
        public Roster Rosters { get; set; }

        public int StudentCount { get; set; }
    }
}