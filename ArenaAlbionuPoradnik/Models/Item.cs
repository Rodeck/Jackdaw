using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class Item
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ProductionExperience { get; set; }
        public int ProductionTime { get; set; }
        public int ProductionCost { get; set; }
        public virtual ICollection<Enemy> Enemies { get; set; }
        public virtual ICollection<NLocation> Locations { get; set; }
        public virtual ICollection<Item> Production { get; set; }
        public virtual ICollection<Item> MaterialsNeeded { get; set; }

        public int? TemporaryImageId { get; set; }
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Medicine,
    Food,
    RawMaterial,
    ProcessedMaterial
}