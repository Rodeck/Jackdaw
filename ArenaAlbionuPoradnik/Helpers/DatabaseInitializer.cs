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

            var items = new List<Item>()
            {
                new Weapon() { Id = 1, Attack = 123, ConditionUse = 5, Name = "Szabla Dżina", Image = Helper.GetItem(), Durability = 2500, Type = ItemType.Weapon, WeaponType = EquipableType.OneHanded, Strength = 10 } ,
                new Weapon() { Id = 2, Attack = 125, ConditionUse = 1, Name = "Trucizna", Image = Helper.GetItem(), Durability = 1, Type = ItemType.Weapon, WeaponType = EquipableType.OneHanded, Strength = 10 },
                new Weapon() { Id = 3, Attack = 152, ConditionUse = 10, Name = "Mamuci Długi Kieł", Image = Helper.GetItem(), Durability = 5200, Type = ItemType.Weapon, WeaponType = EquipableType.DoubleHanded, Strength = 10 },
                new Armor() { Id = 4, Defence = 12, ConditionUse = 5, Name = "Bryna", Image = Helper.GetItem(), Durability = 2500, Type = ItemType.Armor, WeaponType = EquipableType.Chest, Strength = 10 } ,
                new Armor() { Id = 5, Defence = 123, ConditionUse = 1, Name = "Zbroja Legionisty", Image = Helper.GetItem(), Durability = 1, Type = ItemType.Armor, WeaponType = EquipableType.Chest, Strength = 10 },
                new Armor() { Id = 6, Defence = 300, ConditionUse = 10, Name = "Kirys Zmory", Image = Helper.GetItem(), Durability = 5200, Type = ItemType.Armor, WeaponType = EquipableType.Chest, Strength = 10 }
            };


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


            var enemies = new List<Enemy>()
            {
                new Enemy() { Id = 1, Attack = 10, AttackDeviation = 5, Condition = 100, ConditionUse = 2, Defence = 30, Drop = items, Health = 100, Name = "Wilk", Type = EnemyType.Animal },
                new Enemy() { Id = 2, Attack = 15, AttackDeviation = 15, Condition = 1003, ConditionUse = 4, Defence = 300, Drop = items, Health = 300, Name = "Owca", Type = EnemyType.Animal },
                new Enemy() { Id = 3, Attack = 20, AttackDeviation = 2, Condition = 1020, ConditionUse = 5, Defence = 2, Drop = items.Take(2).ToList(), Health = 1200, Name = "Arabski Jeździec", Type = EnemyType.Criminal },
                new Enemy() { Id = 4, Attack = 30, AttackDeviation = 5, Condition = 11300, ConditionUse = 10, Defence = 130, Drop = items.Take(1).ToList(), Health = 14400, Name = "Lodowy Golem", Type = EnemyType.Monstrum },
                new Enemy() { Id = 5, Attack = 50, AttackDeviation = 77, Condition = 133100, ConditionUse = 209, Defence = 3520, Drop = items.Take(2).ToList(), Health = 1100, Name = "Banita", Type = EnemyType.Criminal },
                new Enemy() { Id = 6, Attack = 100, AttackDeviation = 123, Condition = 51100, ConditionUse = 3, Defence = 530, Drop = items.Take(2).ToList(), Health = 1400, Name = "Piaskowy Dżin", Type = EnemyType.Monstrum }
            };


            locations.ForEach(s => s.Enemies = enemies);
            locations.ForEach(s => context.Locations.Add(s));
            enemies.ForEach(s => context.Enemies.Add(s));
            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var places = new List<Place>()
            {
                new Place() { Id = 1, NLocationId = 1, PlaceName = "Arena", Description = "Możesz tutaj toczyć pojedynki", TopX = 10, TopY = 10, BottomX = 20, BottomY = 20 },
                new Place() { Id = 2, NLocationId = 1, PlaceName = "Świątynia", Description = "Wspaniała katedra coś tam coś tam", TopX = 60, TopY = 10, BottomX = 80, BottomY = 20 },
                new Place() { Id = 3, NLocationId = 1, PlaceName = "Kowal", Description = "Możesz tutaj wytworzyć uzbrojenie", TopX = 80, TopY = 10, BottomX = 1000, BottomY = 20 }
            };

            places.ForEach(s => context.Places.Add(s));
            context.SaveChanges();

            var user = new List<User>
            {
                new User() { Id = 1, Name = "SirRysiek", Password = "1234", Regdate = DateTime.Now },
                new User() { Id = 2, Name = "SirRysiek2", Password = "12345", Regdate = DateTime.Now },
                new User() { Id = 3, Name = "SirRysiek3", Password = "haslo", Regdate = DateTime.Now },
            };

            user.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var stories = new List<Story>()
            {
                new Story() { Id = 1, Regdate = DateTime.Now, Title = "Poradnik dla pocątkujących", Text = Helper.GetLorem(), UserId = 1 },
                new Story() { Id = 2, Regdate = DateTime.Now, Title = "Zawody", Text = Helper.GetLorem(), UserId = 1 },
                new Story() { Id = 3, Regdate = DateTime.Now, Title = "Przygody rycerza", Text = Helper.GetLorem(), UserId = 1 },
                new Story() { Id = 4, Regdate = DateTime.Now, Title = "Pustynny kurz", Text = Helper.GetLorem(), UserId = 1 },

                new Story() { Id = 5, Regdate = DateTime.Now, Title = "Cośtam", Text = Helper.GetLorem(), UserId = 2 },
                new Story() { Id = 6, Regdate = DateTime.Now, Title = "Tytuał", Text = Helper.GetLorem(), UserId = 2 },
                new Story() { Id = 7, Regdate = DateTime.Now, Title = "Lorem ipsum", Text = Helper.GetLorem(), UserId = 2 },
                new Story() { Id = 8, Regdate = DateTime.Now, Title = "Text", Text = Helper.GetLorem(), UserId = 2 },

                new Story() { Id = 9, Regdate = DateTime.Now, Title = "Pasdasd", Text = Helper.GetLorem(), UserId = 3 },
                new Story() { Id = 10, Regdate = DateTime.Now, Title = "Quisque", Text = Helper.GetLorem(), UserId = 3 },
                new Story() { Id = 11, Regdate = DateTime.Now, Title = "Quisque rycerza", Text = Helper.GetLorem(), UserId = 3 },
                new Story() { Id = 12, Regdate = DateTime.Now, Title = "Aenean kurz", Text = Helper.GetLorem(), UserId = 3 },
                new Story() { Id = 13, Regdate = DateTime.Now, Title = "Aenean dla pocątkujących", Text = Helper.GetLorem(), UserId = 3 },
                new Story() { Id = 14, Regdate = DateTime.Now, Title = "Nulla", Text = Helper.GetLorem(), UserId = 3 },
                new Story() { Id = 15, Regdate = DateTime.Now, Title = "Nulla rycerza", Text = Helper.GetLorem(), UserId = 3 },
                new Story() { Id = 16, Regdate = DateTime.Now, Title = "Nulla kurz", Text = Helper.GetLorem(), UserId = 3 }
            };

            stories.ForEach(s => context.Stories.Add(s));
            context.SaveChanges();

        }
    }
}