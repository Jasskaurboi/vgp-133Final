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
                //Combat UI
                //menu changed
                //Console.Clear();
                //Console.WriteLine("======THE COMBAT======");
                //Console.WriteLine($"{enemy.name} HP: {enemy.currentHP}/{enemy.maxHP}");
                //Console.WriteLine($"Your HP: {player.currentHP}/{enemy.maxHP}");
                //Console.WriteLine("=======================");
                //Console.WriteLine("Choose one Option:");
                //Console.WriteLine("1. Attack");
                //Console.WriteLine("2. Use Item");
                //Console.WriteLine("3. Flee");
                int input = Convert.ToInt32(Console.ReadLine());

                // Player Attack
                switch (input)
                {
                    case 1:
                        player.Attack();
                        break;
                    case 2:
                        player.UseItem();
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
                
                if(random.NextDouble()<=0.69)
                {
                    //enemy.Attack
                }
                else
                {
                    //enemy.SpecialAttack
                }

            }

        }
    }
}
