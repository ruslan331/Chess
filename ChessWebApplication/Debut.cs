using System;
using System.Collections.Generic;

#nullable disable

namespace ChessWebApplication
{
    public partial class Debut
    {
        public Debut()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
