using ArenaAlbionuPoradnik.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Mappings
{
    public class NKingdomMap: ClassMap<NKingdom>
    {
        public NKingdomMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.NLocation).Inverse().Cascade.All();
        }
    }
}