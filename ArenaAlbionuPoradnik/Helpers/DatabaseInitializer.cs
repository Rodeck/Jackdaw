using ArenaAlbionuPoradnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Helpers
{
    public class DatabaseInitializer: System.Data.Entity.DropCreateDatabaseAlways<AADataContext>
    {
        protected override void Seed(AADataContext context)
        {
            var kingdoms = new List<NKingdom>()
            {
                new NKingdom() { Id = 1, Name = "Albion" },
                new NKingdom() { Id = 2, Name = "Zigura" },
                new NKingdom() { Id = 3, Name = "Orgrod" }
            };

            kingdoms.ForEach(s => context.Kingdoms.Add(s));
            context.SaveChanges();

            var locations = new List<NLocation>()
            {
                new NLocation() { Id = 1, Name = "Dolne Miasto", NKingdomId = 1, Map = Helper.GetMap() },
                new NLocation() { Id = 2, Name = "Górne Miasto", NKingdomId = 1, Map = Helper.GetMap() },
                new NLocation() { Id = 3, Name = "Las", NKingdomId = 1, Map = Helper.GetMap() },

                new NLocation() { Id = 4, Name = "Zigura", NKingdomId = 2, Map = Helper.GetMap() },
                new NLocation() { Id = 5, Name = "Pustynia", NKingdomId = 2, Map = Helper.GetMap() },
                new NLocation() { Id = 6, Name = "Wioska", NKingdomId = 2, Map = Helper.GetMap() },
                new NLocation() { Id = 7, Name = "Port", NKingdomId = 2, Map = Helper.GetMap() },

                new NLocation() { Id = 8, Name = "Port", NKingdomId = 3, Map = Helper.GetMap() },
                new NLocation() { Id = 9, Name = "Orgrod", NKingdomId = 3, Map = Helper.GetMap() },
                new NLocation() { Id = 10, Name = "Wioska", NKingdomId = 3, Map = Helper.GetMap() },
                new NLocation() { Id = 11, Name = "Tajga", NKingdomId = 3, Map = Helper.GetMap() },
            };

            locations.ForEach(s => context.Locations.Add(s));
            context.SaveChanges();

            var items = new List<Item>()
            {
                new Weapon() { Id = 1, Attack = 123, ConditionUse = 5, Name = "Szabla Dżina", Image = Helper.GetItem(), Durability = 2500, Type = ItemType.Weapon, WeaponType = EquipableType.OneHanded, Strength = 10 } ,
                new Weapon() { Id = 2, Attack = 125, ConditionUse = 1, Name = "Trucizna", Image = Helper.GetItem(), Durability = 1, Type = ItemType.Weapon, WeaponType = EquipableType.OneHanded, Strength = 10 },
                new Weapon() { Id = 3, Attack = 152, ConditionUse = 10, Name = "Mamuci Długi Kieł", Image = Helper.GetItem(), Durability = 5200, Type = ItemType.Weapon, WeaponType = EquipableType.DoubleHanded, Strength = 10 },
                new Armor() { Id = 4, Defence = 12, ConditionUse = 5, Name = "Bryna", Image = Helper.GetItem(), Durability = 2500, Type = ItemType.Armor, WeaponType = EquipableType.Chest, Strength = 10 } ,
                new Armor() { Id = 5, Defence = 123, ConditionUse = 1, Name = "Zbroja Legionisty", Image = Helper.GetItem(), Durability = 1, Type = ItemType.Armor, WeaponType = EquipableType.Chest, Strength = 10 },
                new Armor() { Id = 6, Defence = 300, ConditionUse = 10, Name = "Kirys Zmory", Image = Helper.GetItem(), Durability = 5200, Type = ItemType.Armor, WeaponType = EquipableType.Chest, Strength = 10 }
            };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

        }
    }
}