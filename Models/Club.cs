using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtracurricularActivitiyLog.Models
{
    public class Club
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int ClubID { get; set; }

        public string Advisors { get; set; }
        public int Memberships { get; set; }

        public string ClubName { get; set; }

        public ICollection<Roster> Rosters { get; set; }
    }
}
