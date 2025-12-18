using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BossCastle
    {
        private List<Enemy> enemies = new List<Enemy>()
        {
            new Goblin(),
            new Skeleton(),
            new BossEnemy()
        };
        public void RunScene(Player player)
        {
            Random random = new Random();

            //First Fight: 
            Enemy enemy = enemies[0];
            Console.WriteLine($" First fight against {enemy.Name} .");
            Console.ReadKey();
            CombatScene combatScene = new CombatScene();
            if (!combatScene.RunScene(player, enemy))
            {
                return; 
            }

            //Second Fight: 
            enemy = enemies[1];
            Console.WriteLine($" Second fight against {enemy.Name} .");
            Console.ReadKey();
            combatScene = new CombatScene();
            if (!combatScene.RunScene(player, enemy))
            {
                return;
            }

            //Boss Fight:
            enemy = enemies[2];
            Console.WriteLine($" Final fight against {enemy.Name} .");
            Console.ReadKey();
            combatScene = new CombatScene();
            combatScene.RunScene(player, enemy);
        }
    }
}
