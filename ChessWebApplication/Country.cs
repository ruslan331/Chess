using System;
using System.Collections.Generic;

#nullable disable

namespace ChessWebApplication
{
    public partial class Country
    {
        public Country()
        {

            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
