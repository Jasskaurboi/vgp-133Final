using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Skeleton : Enemy
    {
        public Skeleton() : base("Skeleton", EnemyType.Basic, 12, 14, 3, 9, 4)
        {

        }

        public override void SpecialAttack(Player player)
        {

            Console.WriteLine($"{Name} used special attack.");
        }
    }
}
