using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class ProcessedMaterial: DatabaseItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
    }
}