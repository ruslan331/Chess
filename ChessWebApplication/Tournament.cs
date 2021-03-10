using System;
using System.Collections.Generic;

#nullable disable

namespace ChessWebApplication
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Winner { get; set; }

        public virtual Player WinnerNavigation { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
