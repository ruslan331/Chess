using System;
using System.Collections.Generic;

#nullable disable

namespace ChessWebApplication
{
    public partial class Move
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Move1 { get; set; }
        public bool Color { get; set; }
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }
    }
}
