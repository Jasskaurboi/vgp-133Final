using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BigLeech : Enemy
    {
        public BigLeech() : base("BigLeech", EnemyType.Basic, 13, 15, 4, 10, 5)
        {

        }

        public override void SpecialAttack(Player player)
        {
            Console.WriteLine($"{Name} used special attack.");
            player.TakeDamage(Att);
            Console.WriteLine($"{Name} Leech live.");
            UpdateHealth(Att);

        }
    }
}
