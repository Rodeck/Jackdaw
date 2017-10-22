using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class Weapon: Equipable
    {
        public int Attack { get; set; }
        
    }

    public class Armor: Equipable
    {
        public int Defence { get; set; }
    }

    public class Equipable: Item
    {
        public int ConditionUse { get; set; }
        public int Durability { get; set; }
        public int Strength { get; set; }
        public EquipableType WeaponType { get; set; }
    }
}

public enum EquipableType
{
    OneHanded,
    DoubleHanded,
    Bow,
    Chest,
    Shoulders,
    Greaves,
    Shields
}