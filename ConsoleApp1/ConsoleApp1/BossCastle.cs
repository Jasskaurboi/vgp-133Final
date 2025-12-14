using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BossCastle
    {
        public void RunScene(Player player)
        {
            Random random = new Random();
            if (random.NextDouble() < 0.5)
            {
                Console.WriteLine("You found an item!");
                //Item drop= new Item();
                // player.AddItem(drop);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You found an enemy!");
                Console.ReadKey();
                CombatScene combatScene = new CombatScene();

                Enemy enemy = new Enemy();
                combatScene.RunScene(player, enemy);
            }
        }
    }
}
