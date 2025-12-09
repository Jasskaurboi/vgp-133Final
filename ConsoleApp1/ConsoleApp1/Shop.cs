using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Shop
    {
        private List<Item> consumables = new List<Item>()
        {
             new Consumable("Small Potion", 10, 20),
            new Consumable("Medium Potion", 20, 40),
            new Consumable("Large Potion", 30, 60)
        };

        private List<Item> equipments = new List<Item>()
        {
            new Weapon("Wooden Sword",0,25,30,25),
            new Weapon("Iron Sword", 1,20,38,30),
            new Armor("Cloth Armor",4,30,40,20 ),
            new Armor("Iron Armor", 2,45,60,65)
        };

        public void RunScene(Player player, string shopType)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========shop==========");
                Console.WriteLine($"your gold: {player.UpdateGold}");

                Console.WriteLine();

                List<Item> shopList = new List<Item>();

                if (shopType == "consumable")
                {
                    shopList.AddRange(consumables);
                }
                else if (shopType == "equipment")
                {
                    shopList.AddRange(equipments);
                }


                for (int i = 0; i < shopList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{shopList[i].Name}-{shopList[i].Price} gold");
                }

            }

        }
    }
}
