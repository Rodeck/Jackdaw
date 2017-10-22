using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class NKingdom
    {
        public virtual int  Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<NLocation> NLocation { get; set; }
    }
}