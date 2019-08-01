using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceships
{
   public class Ship
    {
       public string Name;
        public int Health;
        public int Armor;
        public int Cost;
        public int Damage;
        public int Speed;
        public int Evasion;

        public Ship(int health, int armor, int cost, int damage, int speed, int evasion, string _name)
        {
            Armor = armor;
            Cost = cost;
            Damage = damage;
            Health = health;
            Speed = speed;
            Evasion = evasion;
            Name = _name;
        }
       public bool GetDamage(int dmg)
        {
            Health -= dmg;
            if (Health < 0) return false;
            else return true;
        }
    }
}
