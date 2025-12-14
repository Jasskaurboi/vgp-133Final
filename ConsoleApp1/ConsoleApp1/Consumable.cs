using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Consumable:Item
    {
        private int healAmount;
        public int HealAmount { get { return healAmount; } }

        public Consumable(string name, int healAmount, int price) : base(name, price,ItemType.Consumable) 
        {
            this.healAmount = healAmount;

        }

    }
}
