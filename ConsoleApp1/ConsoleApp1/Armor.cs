using System;

namespace ConsoleApp1
{
    public class Armor :Equipment
    {
        public Armor(string name, int hp, int attack, int defence, int price) : base(name, hp, attack, defence, price)
        {
            Type = EquipmentType.Armor;
        }
    }
}
