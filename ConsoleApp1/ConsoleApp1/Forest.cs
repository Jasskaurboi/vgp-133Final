using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Forest
    {

        private List<Item> dropList = new List<Item>()
        {
             new Consumable("Small Potion", 10, 20),
             new Equipment("Wooden Sword",0,25,30,25, EquipmentType.Weapon),
             new Equipment("Cloth Armor",4,30,40,20,EquipmentType.Armor )
        };
        public void RunScene(Player player)
        {
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
                Console.WriteLine("You found an enemy!");
                Console.ReadKey();
                CombatScene combatScene = new CombatScene();

                Enemy enemy = new Enemy();
                combatScene.RunScene(player, enemy);
            }
        }
    }
}
