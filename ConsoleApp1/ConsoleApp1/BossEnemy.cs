using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BossEnemy : Enemy
    {
        public BossEnemy() : base("BossEnemy", EnemyType.Boss, 30, 25, 17, 24, 16)
        {

        }

        public override void SpecialAttack(Player player)
        {
            Random random = new Random();

            int special = random.Next(1, 6);
            if (special == 1)
            {
                if (random.NextDouble() <= 0.6)
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
            else if (special == 2)
            {
                int attacks = random.Next(1, 4);
                for (int i = 0; i < attacks; i++)
                {
                    Console.WriteLine($"{Name} used special attack.");
                    player.TakeDamage(Att);

                }

            }
            else if (special == 3)
            {

                Console.WriteLine($"{Name} used special attack.");
                player.TakeDamage(Att);
                Console.WriteLine($"{Name} Leech live.");
                UpdateHealth(Att);


            }
            else if (special == 4)
            {

                Console.WriteLine($"{Name} used special attack.");
                player.TakeDamage(Att);
                Console.WriteLine($"{Name} stole some gold.");
                player.UpdateGold(-3);
                GoldDrop += 3;


            }
            else if (special == 5)
            {
                int currentChance = 100;
                while (random.Next(100) < currentChance)
                {
                    Console.WriteLine($"{Name} used special attack.");
                    player.TakeDamage(Att);
                    currentChance -= 25;
                }
            }
            else
            {

            }


        }
    }
}
