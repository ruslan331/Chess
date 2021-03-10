using System;
using System.Collections.Generic;

#nullable disable

namespace ChessWebApplication
{
    public partial class Player
    {
        public Player()
        {
            MatchPlayerId1Navigations = new HashSet<Match>();
            MatchPlayerId2Navigations = new HashSet<Match>();
            Tournaments = new HashSet<Tournament>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public int? CounrtyId { get; set; }

        public virtual Country Counrty { get; set; }
        public virtual ICollection<Match> MatchPlayerId1Navigations { get; set; }
        public virtual ICollection<Match> MatchPlayerId2Navigations { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
