using System;
using System.Collections.Generic;

#nullable disable

namespace ChessWebApplication
{
    public partial class Match
    {
        public Match()
        {
            Moves = new HashSet<Move>();
        }

        public int Id { get; set; }
        public int PlayerId1 { get; set; }
        public int PlayerId2 { get; set; }
        public string Result1 { get; set; }
        public string Result2 { get; set; }
        public int DebutId { get; set; }
        public int TournamentId { get; set; }

        public virtual Debut Debut { get; set; }
        public virtual Player PlayerId1Navigation { get; set; }
        public virtual Player PlayerId2Navigation { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<Move> Moves { get; set; }
    }
}
