using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public EnemyType Type { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int AttackDeviation { get; set; }
        public int Defence { get; set; }
        public int Health { get; set; }
        public int Condition { get; set; }
        public int ConditionUse { get; set; }
        public virtual ICollection<Item> Drop { get; set; }
        public virtual ICollection<NLocation> Locations { get; set; }
    }
}

public enum EnemyType
{
    Animal,
    Criminal,
    Monstrum
}