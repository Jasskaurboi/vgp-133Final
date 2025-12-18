using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Mountain
    {
        private List<Item> dropList = new List<Item>()
        {
            new Consumable("Medium Potion", 20, 40),
            new Equipment("Iron Sword", 1,20,38,30, EquipmentType.Weapon),
            new Equipment("Iron Armor", 2,45,60,65, EquipmentType.Armor)
        };

        private List<Enemy> enemies = new List<Enemy>()
        {
            new BigLeech(),
            new Imptheif(),
            new PeskyBoomerang()
        };

        public void RunScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("MOUNTAIN!!");
            Console.WriteLine($"{player.CurrentHP}/{player.MaxHP}hp | {player.Gold}g");
            Random random = new Random();
            if (random.NextDouble() < 0.5)
            {
                int randomItem = random.Next(dropList.Count);
                if (dropList[randomItem].Type == ItemType.Consumable)
                {

                    Consumable newItem = new Consumable(dropList[randomItem].Name, ((Consumable)dropList[randomItem]).HealAmount, dropList[randomItem].Price);
                    player.AddItemToInventory(newItem);
                    Console.WriteLine($"You found a {newItem.Name}!");
                }
                else if (dropList[randomItem].Type == ItemType.Equipment)
                {
                    Equipment newItem = new Equipment(dropList[randomItem].Name, ((Equipment)dropList[randomItem]).HP, ((Equipment)dropList[randomItem]).Attack, ((Equipment)dropList[randomItem]).Defence, dropList[randomItem].Price, ((Equipment)dropList[randomItem]).Type);
                    player.AddItemToInventory(newItem);
                    Console.WriteLine($"You found a {newItem.Name}!");
                }
                int goldDrop = random.Next(1, 11);
                player.UpdateGold(goldDrop);
                Console.WriteLine($"You got {goldDrop} gold.");
                Console.ReadKey();
            }
            else
            {
                int randomEnemy = random.Next(enemies.Count);

                Enemy enemy = enemies[randomEnemy];

                Console.WriteLine($"You found dangerous {enemy.Name}!");


                Console.ReadKey();
                CombatScene combatScene = new CombatScene();

                combatScene.RunScene(player, enemy);
            }
        }
    }
}
