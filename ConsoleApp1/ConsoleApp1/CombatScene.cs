using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CombatScene
    {
        public void RunScene(Player player, Enemy enemy)
        {

            Random random = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("======THE COMBAT======");
                Console.WriteLine($"{enemy.Name} HP: {enemy.CurrentHP}/{enemy.MaxHP}");
                Console.WriteLine($"Your HP: {player.CurrentHP}/{player.MaxHP}");
                Console.WriteLine("=======================");
                Console.WriteLine("Choose one Option:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Item");
                Console.WriteLine("3. Flee");
                int input = Convert.ToInt32(Console.ReadLine());

                // Player Attack
                switch (input)
                {
                    case 1:
                        player.Attack(enemy);
                        break;
                    case 2:
                        player.UseItem();
                        break;
                    case 3:
                        Console.WriteLine("You ran away successfully!!");
                        Console.ReadKey();
                        return;
                    default:
                        break;
                }

                Console.ReadKey();
                if (enemy.CurrentHP <= 0)
                {
                    // you won!!
                    player.UpdateGold(enemy.GoldDrop);
                    player.UpdateExp(enemy.XPDrop);
                    Console.WriteLine("You won the battle!!");
                    Console.ReadKey();
                    return;
                }

                if (random.NextDouble() <= 0.69)
                {
                    enemy.Attack(player);
                }
                else
                {
                    //enemy.SpecialAttack
                }

                //you lost
                if (player.CurrentHP <= 0)
                {
                    player.CombatLose();
                    Console.ReadKey();
                    return;
                }
                Console.ReadKey();
            }

        }
    }
}
