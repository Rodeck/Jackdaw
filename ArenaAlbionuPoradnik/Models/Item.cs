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
        public ICollection<Enemy> Enemies { get; set; }
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Medicine,
    Food
}