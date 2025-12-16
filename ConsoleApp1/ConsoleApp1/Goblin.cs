using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Goblin : Enemy
    {
        public Goblin() : base("Goblin", EnemyType.Basic, 10, 12, 2, 10, 5)
        {

        }

        public override void SpecialAttack(Player player)
        {
            Random random = new Random();

            if(random.NextDouble()<=0.6)
            {
                Console.WriteLine($"{Name} is attacking {player.Name} with their special attack!");
                int damage = Att * 2;
                player.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine("It missed with its special attack.");
            }
        }
    }
}
