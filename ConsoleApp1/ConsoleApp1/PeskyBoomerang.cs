using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PeskyBoomerang : Enemy
    {
        public PeskyBoomerang() : base("PeskyBoomerang", EnemyType.Basic, 16, 15, 7, 14, 6)
        {

        }

        public override void SpecialAttack(Player player)
        {
            Random random = new Random();
            int currentChance = 100;
            while (random.Next(100) < currentChance)
            {
                Console.WriteLine($"{Name} used special attack.");
                player.TakeDamage(Att);
                currentChance -= 25;
            }
        }
    }
}
