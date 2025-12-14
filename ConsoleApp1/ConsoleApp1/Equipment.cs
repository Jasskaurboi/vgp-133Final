using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Equipment : Item
    {
        public EquipmentType Type { get; set; }
        public int HP { get; set; }

        public int Attack { get; set; }
        public int Defence { get; set; }

        public Equipment(string name, int hp, int attack, int defence, int price, EquipmentType type):base (name,price, ItemType.Equipment)
        {
           Type = type;
            HP = hp; 
            Attack = attack;
            Defence = defence;
        }


    }


}
