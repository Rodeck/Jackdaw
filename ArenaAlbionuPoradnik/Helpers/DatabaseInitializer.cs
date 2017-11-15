using ArenaAlbionuPoradnik.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ArenaAlbionuPoradnik.Helpers
{
    public class DatabaseInitializer: System.Data.Entity.DropCreateDatabaseAlways<AADataContext>
    {

        public List<Item> GetItemsById(List<Item> all, List<int> ids)
        {
            List<Item> items = new List<Item>();

            foreach(int id in ids)
            {
                items.Add(all.Where(s => s.Id == id).FirstOrDefault());
            }

            return items;
        }

        public List<NLocation> GetItemsById(List<NLocation> all, List<int> ids)
        {
            List<NLocation> items = new List<NLocation>();

            foreach (int id in ids)
            {
                items.Add(all.Where(s => s.Id == id).FirstOrDefault());
            }

            return items;
        }

        private void LoadImage(Item item)
        {
            string location = WebConfigurationManager.AppSettings["ItemImageLocation"];

            string path = location + "//" + item.TemporaryImageId + ".gif";

            item.Image = GetImage(path);
        }

        private void LoadLocationImage(NLocation location)
        {
            string basePath = WebConfigurationManager.AppSettings["MapImageLocation"];
            string path = basePath + "//" + location.TemporaryImageId + ".jpg";

            location.Map = GetImage(path);

        }

        public string GetImage(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }

        protected override void Seed(AADataContext context)
        {
            var kingdoms = new List<NKingdom>()
            {
                new NKingdom() { Id = 1, Name = "Albion" },
                new NKingdom() { Id = 2, Name = "Zigura" },
                new NKingdom() { Id = 3, Name = "Orgrod" },
                new NKingdom() { Id = 4, Name = "Dorstar" },
                new NKingdom() { Id = 5, Name = "Amazonki" },
                new NKingdom() { Id = 6, Name = "Tereny Neutralne" },
                new NKingdom() { Id = 7, Name = "Hardron" },
                new NKingdom() { Id = 8, Name = "KurKor" }
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
                new Armor() { Id = 6, Defence = 300, ConditionUse = 10, Name = "Kirys Zmory", Image = Helper.GetItem(), Durability = 5200, Type = ItemType.Armor, WeaponType = EquipableType.Chest, Strength = 10 },
                new Armor() { Id = 7, Name = "Hełm Żebrowy", ConditionUse = 1, Defence = 9, Durability = 220, Image = Helper.GetItem(), Strength = 1, Type = ItemType.Armor, WeaponType = EquipableType.Helmet, TemporaryImageId = 2 },
                new Armor() { Id = 8, Name = "Psi Pysk", ConditionUse = 3, Defence = 35, Durability = 220, Image = Helper.GetItem(), Strength = 13, Type = ItemType.Armor, WeaponType = EquipableType.Helmet, TemporaryImageId = 74 },
                new Armor() { Id = 9, Name = "Bryna", ConditionUse = 2, Defence = 38, Durability = 300, Image = Helper.GetItem(), Strength = 3, Type = ItemType.Armor, WeaponType = EquipableType.Helmet },
                new Weapon() { Id = 10, Name = "Maczuga", ConditionUse = 1, Attack = 38, Durability = 300, Image = Helper.GetItem(), Strength = 3, Type = ItemType.Weapon, WeaponType = EquipableType.OneHanded },
                new Weapon() { Id = 11, Name = "Pika", ConditionUse = 1, Attack = 38, Durability = 300, Image = Helper.GetItem(), Strength = 3, Type = ItemType.Weapon, WeaponType = EquipableType.DoubleHanded },
                new Weapon() { Id = 12, Name = "Cep Bojowy", ConditionUse = 1, Attack = 38, Durability = 300, Image = Helper.GetItem(), Strength = 3, Type = ItemType.Weapon, WeaponType = EquipableType.OneHanded },
                new Weapon() { Id = 13, Name = "Młot Bojowy", ConditionUse = 1, Attack = 38, Durability = 300, Image = Helper.GetItem(), Strength = 3, Type = ItemType.Weapon, WeaponType = EquipableType.OneHanded },
                new Item() { Id = 90, Image = Helper.GetItem(), Name = "Stal", Type = ItemType.ProcessedMaterial },
                new Item() { Id = 100, Image = Helper.GetItem(), Name = "Żelazo", Type = ItemType.RawMaterial, TemporaryImageId = 47 },
                new Item() { Id = 101, Image = Helper.GetItem(), Name = "Skóra garbowana", Type = ItemType.ProcessedMaterial },
                new Item() { Id = 102, Image = Helper.GetItem(), Name = "Skóra", Type = ItemType.RawMaterial, TemporaryImageId = 48 },
                new Item() { Id = 103, Image = Helper.GetItem(), Name = "Czarnoziem", Type = ItemType.RawMaterial },
                new Item() { Id = 104, Image = Helper.GetItem(), Name = "Len", Type = ItemType.ProcessedMaterial },
                new Item() { Id = 105, Image = Helper.GetItem(), Name = "Sznurek", Type = ItemType.ProcessedMaterial },
                new Item() { Id = 105, Image = Helper.GetItem(), Name = "Dębowy drąg", Type = ItemType.RawMaterial, TemporaryImageId = 46 },
                new Item() { Id = 110, Image = Helper.GetItem(), Name = "Węgiel", Type = ItemType.RawMaterial },
                new Item() { Id = 111, Image = Helper.GetItem(), Name = "Kamień", Type = ItemType.RawMaterial, TemporaryImageId = 49 },
                new Item() { Id = 112, Image = Helper.GetItem(), Name = "Rogi", Type = ItemType.RawMaterial, TemporaryImageId = 44 }
            };

            items.Where(s => s.Id == 100).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 7, 8, 90 });
            items.Where(s => s.Id == 110).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 7, 8, 90 });
            items.Where(s => s.Id == 7).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 100 });
            items.Where(s => s.Id == 8).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 90, 101, 105 });
            items.Where(s => s.Id == 9).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 101, 100, 105 });
            items.Where(s => s.Id == 10).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 105, 100 });
            items.Where(s => s.Id == 13).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 105, 90 });
            items.Where(s => s.Id == 11).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 105, 100 });
            items.Where(s => s.Id == 12).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 105, 90, 105 });
            items.Where(s => s.Id == 102).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 101 });
            items.Where(s => s.Id == 103).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 104 });

            items.Where(s => s.Id == 90).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 8, 13, 12});
            items.Where(s => s.Id == 101).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 8 , 9 });
            items.Where(s => s.Id == 104).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 105 });
            items.Where(s => s.Id == 105).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 8, 9, 12 });


            items.Where(i => i.TemporaryImageId != null).ToList().ForEach(i => LoadImage(i));

            var locations = new List<NLocation>()
            {
                new NLocation() { Id = 1, Name = "Dolne Miasto", NKingdomId = 1, Map = Helper.GetMap() },
                new NLocation() { Id = 2, Name = "Górne Miasto", NKingdomId = 1, TemporaryImageId = 35 },
                new NLocation() { Id = 13, Name = "Wioska", NKingdomId = 1, TemporaryImageId = 4 },

                new NLocation() { Id = 3, Name = "Las", NKingdomId = 5, TemporaryImageId =  0},
                new NLocation() { Id = 3, Name = "Osada Amazonek", NKingdomId = 5, TemporaryImageId = 16  },

                new NLocation() { Id = 12, Name = "Dorstar", NKingdomId = 4, TemporaryImageId = 10 },

                new NLocation() { Id = 4, Name = "Zigura", NKingdomId = 2, TemporaryImageId = 7 },
                new NLocation() { Id = 5, Name = "Pustynia", NKingdomId = 2, TemporaryImageId = 6 },
                new NLocation() { Id = 6, Name = "Wioska", NKingdomId = 2, TemporaryImageId = 9 },
                new NLocation() { Id = 7, Name = "Port", NKingdomId = 2, TemporaryImageId = 8 },

                new NLocation() { Id = 8, Name = "Port", NKingdomId = 3, TemporaryImageId = 11 },
                new NLocation() { Id = 9, Name = "Orgrod", NKingdomId = 3, TemporaryImageId = 12 },
                new NLocation() { Id = 10, Name = "Wioska", NKingdomId = 3, TemporaryImageId = 13 },
                new NLocation() { Id = 11, Name = "Tajga", NKingdomId = 3, TemporaryImageId = 14 },

                new NLocation() { Id = 14, Name = "Góry Orle", NKingdomId = 6, TemporaryImageId = 5 },
                new NLocation() { Id = 15, Name = "Lodowiec", NKingdomId = 6, TemporaryImageId = 15 },
                new NLocation() { Id = 22, Name = "Wyżyna", NKingdomId = 6, TemporaryImageId = 29 },

                new NLocation() { Id = 17, Name = "Hardron", NKingdomId = 7, TemporaryImageId = 18 },
                new NLocation() { Id = 16, Name = "Tundra", NKingdomId = 7, TemporaryImageId = 17 },

                new NLocation() { Id = 18, Name = "Step LiuKi", NKingdomId = 8, TemporaryImageId = 19 },
                new NLocation() { Id = 19, Name = "KurKor", NKingdomId = 8, TemporaryImageId = 20 },
                new NLocation() { Id = 20, Name = "Dzielnica 1000 Rzemiosł", NKingdomId = 8, TemporaryImageId = 21 },
                new NLocation() { Id = 21, Name = "Archipelag Imoto", NKingdomId = 8, TemporaryImageId = 22 },
            };

            locations.Where(i => i.TemporaryImageId != null).ToList().ForEach(i => LoadLocationImage(i));

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
                new Place() { Id = 1, NLocationId = 1 , PlaceName = "Arena", Description = "Miejsce pojedynków pomiędzy rycerzami wszystkich aren Areny Albionu, z wyjątkiem tej na Wyspie Dziewic." , TopX = 51, TopY = 11, BottomX = 188, BottomY = 131 },
                new Place() { Id = 2, NLocationId = 1 , PlaceName = "Świątnia", Description = "Description" , TopX = 205, TopY = 12, BottomX = 308, BottomY = 140 },
                new Place() { Id = 3, NLocationId = 1 , PlaceName = "Kowal", Description = "Możesz zatrudnić się jako czeladnik kowala, jeżeli masz 2 poziom parobka, młotek oraz dostarczysz 20 żelaza. Jeżeli masz 2 poziom w zawodzie kowal oraz młotek, możesz zamówić:" , TopX = 344, TopY = 28, BottomX = 458, BottomY = 118 , IsProductionPlace = true},
                new Place() { Id = 4, NLocationId = 1 , PlaceName = "Lichwiarz", Description = "Description" , TopX = 19, TopY = 140, BottomX = 124, BottomY = 224 },
                new Place() { Id = 5, NLocationId = 1 , PlaceName = "Sklep", Description = "Description" , TopX = 257, TopY = 171, BottomX = 324, BottomY = 240 },
                new Place() { Id = 6, NLocationId = 1 , PlaceName = "Koszary", Description = "Description" , TopX = 344, TopY = 125, BottomX = 476, BottomY = 218 },
                new Place() { Id = 7, NLocationId = 1 , PlaceName = "Pieczary", Description = "Description" , TopX = 57, TopY = 228, BottomX = 180, BottomY = 283 },
                new Place() { Id = 8, NLocationId = 1 , PlaceName = "Droga", Description = "Nikt nie może tutaj okraść ani zaatakować Twojego rycerza, może on jednak zostać uwięziony w baszcie przez króla lub strażnika. Na słupie możesz umieścić swoje ogłoszenie (jedno na turę). Jeżeli masz więcej czasu, kup sobie gazetkę." , TopX = 196, TopY = 210, BottomX = 239, BottomY = 252 },
                new Place() { Id = 9, NLocationId = 1 , PlaceName = "Stadnina", Description = "Description" , TopX = 331, TopY = 226, BottomX = 465, BottomY = 314 },
                new Place() { Id = 10, NLocationId = 1 , PlaceName = "Bazar", Description = "Lokalne targowisko. Procent prowizji ustalany jest przez króla." , TopX = 209, TopY = 295, BottomX = 327, BottomY = 384 },
                new Place() { Id = 11, NLocationId = 1 , PlaceName = "Gospoda", Description = "Możesz tu zagrać w kości. Obstawiasz liczbę i czekasz na zakończenie tury. Zebrana kwota dzielona jest pomiędzy zwycięzców. Możesz też wynająć jeden z dostępnych pokoi, aby regenerować się szybciej. W gospodzie możesz porozmawiać na lokalnym \"czacie\" z rycerzami ze wszystkich podobnych miejsc w grze." , TopX = 39, TopY = 322, BottomX = 168, BottomY = 399 },
                new Place() { Id = 12, NLocationId = 1 , PlaceName = "Las", Description = "Description" , TopX = 355, TopY = 327, BottomX = 479, BottomY = 399 },

                new Place() { Id = 13, NLocationId = 2 , PlaceName = "Złotnik", Description = "Możesz zrobić sam jeśli masz minimum 2 poziom rzemieslnika i sprawny młotek. Ty aktualnie masz x poziom rzemieslnika, x młotek" , TopX = 25, TopY = 304, BottomX = 156, BottomY = 379 },
                new Place() { Id = 14, NLocationId = 2 , PlaceName = "Płatnerz", Description = "" , TopX = 307, TopY = 294, BottomX = 425, BottomY = 386 },
                new Place() { Id = 15, NLocationId = 2 , PlaceName = "Dom kurtyzan", Description = "" , TopX = 25, TopY = 212, BottomX = 201, BottomY = 300 },
                new Place() { Id = 16, NLocationId = 2 , PlaceName = "Straż miejska", Description = "" , TopX=   260 ,   TopY =  214 ,   BottomX =   427 ,   BottomY =   290},
                new Place() { Id = 17, NLocationId = 2 , PlaceName = "Baszta skazańcow", Description = "" , TopX=    249 ,   TopY =  73  ,   BottomX =   359 ,   BottomY =   208 },
                new Place() { Id = 18, NLocationId = 2 , PlaceName = "Pałac władcy,", Description = "" , TopX=   9   ,   TopY =  103 ,   BottomX =   198 ,   BottomY =   207 },
                new Place() { Id = 19, NLocationId = 2 , PlaceName = "Wioska", Description = "" , TopX=  144 ,   TopY =  93  ,   BottomX =   234 ,   BottomY =   94 }
            };

            var sections = new List<TextSection>()
            {
                new TextSection() {Id = 1, Text = "Możesz tutaj sprzedać drogocenne kamienie, klejnoty i przedmioty</br>Mając lunetę i młotek po skruszeniu kamienia możesz wyczytać z gwiazd czy dany kamień ma ukrytą moc diamentu, kamienia filozoficznego lub inną</br>Ty masz aktualnie x kamieni, x młotek, x luneta</br>/br>Tutejsi handlarze z chęcią zakupią wszelkie ilości sztabek złota i guldenów. Aktualna cena za 1 szt. sztabki to x talary i za monetę 20 guldenów to y talary</br>Ty masz aktualnie 0 sztabek złota i 0 guldenów" },
                new TextSection() {Id = 2, Text = "Aktualnie możesz spotkać się z następującymi Paniami.</br>Spotkanie zwiększy Twoją sprawność (ciekawe czego ?)." }
            };

            places.Where(s => s.Id == 13).FirstOrDefault().Sections = sections.Where(s => s.Id == 1).ToList();
            places.Where(s => s.Id == 15).FirstOrDefault().Sections = sections.Where(s => s.Id == 2).ToList();

            places.Where(s => s.Id == 3).FirstOrDefault().Production = GetItemsById(items, new List<int>() { 7, 8, 9, 10, 11, 12, 13 });

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

            var menu = new List<MenuModel>()
            {
                new MenuModel() { Id = 1, Active = true}
            };

            var menuItems = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Text = "Królestwa" },
                new MenuItem() { Id = 2, Text = "Uzbrojenie" },
                new MenuItem() { Id = 3, Text = "Przedmioty" },
                new MenuItem() { Id = 4, Text = "Klaudia" }
            };

            var kingdomMenuList = new List<MenuSubItem>();

            foreach(var kingdom in kingdoms)
            {
                MenuSubItem item = new MenuSubItem();
                item.ActionName = "Index";
                item.ControllerName = "Kingdom";
                item.Id = kingdom.Id;
                item.Value = kingdom.Id;
                item.Text = kingdom.Name;
                kingdomMenuList.Add(item);
            }

            menuItems.Where(s => s.Id == 1).FirstOrDefault().SubItems = kingdomMenuList;

            //Equipment

            var eqList = new List<MenuSubItem>()
            {
                new MenuSubItem() { Id = 1, Text = "Broń jednoręczna", ControllerName = "Weapons", ActionName = "WeaponType", ValueS = "OneHanded"},
                new MenuSubItem() { Id = 2, Text = "Broń dwuręczna", ControllerName = "Weapons", ActionName = "WeaponType", ValueS = "DoubleHanded"},
                new MenuSubItem() { Id = 3, Text = "Broń dystansowa", ControllerName = "Weapons", ActionName = "WeaponType", ValueS = "Bow"},

                new MenuSubItem() { Id = 4, Text = "Hełmy", ControllerName = "Weapons", ActionName = "ArmorType", ValueS = "Helmet"},
                new MenuSubItem() { Id = 5, Text = "Tarcze", ControllerName = "Weapons", ActionName = "ArmorType", ValueS = "Shields"},
                new MenuSubItem() { Id = 6, Text = "Napierśniki", ControllerName = "Weapons", ActionName = "ArmorType", ValueS = "Chest"},
                new MenuSubItem() { Id = 7, Text = "Naramienniki", ControllerName = "Weapons", ActionName = "ArmorType", ValueS = "Shoulders"},
                new MenuSubItem() { Id = 8, Text = "Nagolenniki", ControllerName = "Weapons", ActionName = "ArmorType", ValueS = "Greaves"}
            };

            menuItems.Where(s => s.Id == 2).FirstOrDefault().SubItems = eqList;

            menu.Where(s => s.Id == 1).FirstOrDefault().MenuItems = menuItems;
            menu.Where(s => s.Id == 1).FirstOrDefault().State = SiteState.LogedOut;
            menu.ForEach(s => context.Menu.Add(s));
            context.SaveChanges();



        }
    }
}