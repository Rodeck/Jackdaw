using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class Place
    {
        public virtual int Id { get; set; }
        public virtual int NLocationId { get; set; }
        public virtual NLocation NLocation { get; set; }

        public virtual int TopX { get; set; }
        public virtual int TopY { get; set; }

        public virtual int BottomX { get; set; }
        public virtual int BottomY { get; set; }

        public string PlaceName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Production { get; set; }
        public virtual ICollection<TextSection> Sections { get; set; }

        public bool IsProductionPlace { get; set; }
        public string ProductionText { get; set; }
    }
}