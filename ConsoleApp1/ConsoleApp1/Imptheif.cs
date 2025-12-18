using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Imptheif:Enemy
    {
        public Imptheif() : base("Imptheif", EnemyType.Basic, 10, 11, 5, 11, 4)
        {

        }

        public override void SpecialAttack(Player player)
        {
            Console.WriteLine($"{Name} used special attack.");
            player.TakeDamage(Att);
            Console.WriteLine($"{Name} stole some gold.");
            player.UpdateGold(-3);
            GoldDrop += 3;
        }
    }
}
