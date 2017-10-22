using ArenaAlbionuPoradnik.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Mappings
{
    public class NLocationMap: ClassMap<NLocation>
    {
        public NLocationMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Map);
            //References(x => x.NKingdom);
        }
    }
}