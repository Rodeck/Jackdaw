using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class NLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public int NKingdomId { get; set; }
        public int CreationTurn { get; set; }
        public virtual NKingdom Kingdom { get; set; }
    }
}