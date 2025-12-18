using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CombatScene
    {
        public bool RunScene(Player player, Enemy enemy)
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

                int input = -1;

                while (true)
                {

                    if (int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= 3)
                    {
                        break;
                    }
                }
                
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
                        if(enemy.Type== EnemyType.Boss)
                        {
                            Console.WriteLine("Can't run away from he boss!!");
                        }
                        else
                        {
                            Console.WriteLine("You ran away successfully!!");
                        }

                        return false;
                    default:
                        break;
                }

                Console.ReadKey();
                if (enemy.CurrentHP <= 0)
                {
                    if(enemy.Type==EnemyType.Boss)
                    {
                        Console.WriteLine("You beat the Game!!!");
                        player.WinTheGame();
                        Console.ReadKey();
                        return true;
                    }
                    // you won!!
                    Console.WriteLine("You won the battle!!");
                    player.UpdateGold(enemy.GoldDrop);
                    player.UpdateExp(enemy.XPDrop);
                    return true;
                }

                if (random.NextDouble() <= 0.09)
                {
                    enemy.Attack(player);
                }
                else
                {
                    enemy.SpecialAttack(player);
                }

                //you lost
                if (player.CurrentHP <= 0)
                {
                    player.CombatLose();
                    Console.ReadKey();
                    return false;
                }
                Console.ReadKey();
            }

        }
    }
}
