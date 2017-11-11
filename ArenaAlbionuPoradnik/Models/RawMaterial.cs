using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class RawMaterial : DatabaseItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<NLocation> Locations { get; set; }
        public virtual ICollection<ProcessedMaterial> Production { get; set; }
    }
}