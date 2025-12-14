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
            new Equipment("Wooden Sword",0,25,30,25, EquipmentType.Weapon),
            new Equipment("Iron Sword", 1,20,38,30, EquipmentType.Weapon),
            new Equipment("Cloth Armor",4,30,40,20,EquipmentType.Armor ),
            new Equipment("Iron Armor", 2,45,60,65, EquipmentType.Armor)
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

                Console.WriteLine("0. Exit shop.");

                for (int i = 0; i < shopList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{shopList[i].Name}-{shopList[i].Price} gold");
                }

                int input = -1;

                while(true)
                {
                    Console.WriteLine("Select an item:");

                    if (int.TryParse(Console.ReadLine(), out input) && input >= 0&& input<=shopList.Count)
                    {
                        break;
                    }

                    // input=Convert.ToInt32( Console.ReadLine() );
                    //if(input>shopList.Count && input<0)
                    //{
                    //    break;
                    //}
                }
                if(input==0)
                {
                    Console.WriteLine("Leaving the shop.");
                    return;
                }
                if (player.Gold < shopList[input-1].Price)
                {
                    Console.WriteLine("You don't have enough gold!!");
                    Console.ReadKey();
                }
                else
                {
                    player.UpdateGold(shopList[input-1].Price);
                    Console.WriteLine($"Bought{shopList[input - 1].Name} for {shopList[input - 1].Price}");

                    if(shopList[input - 1].Type==ItemType.Consumable)
                    {
                        Consumable newItem = new Consumable(shopList[input - 1].Name, ((Consumable)shopList[input - 1]).HealAmount, shopList[input - 1].Price);  //ask professor
                        player.AddItemToInventory(newItem);
                    }
                    else if (shopList[input - 1].Type == ItemType.Equipment)
                    {
                        Equipment newItem = new Equipment(shopList[input - 1].Name, ((Equipment)shopList[input - 1]).HP, ((Equipment)shopList[input - 1]).Attack, ((Equipment)shopList[input - 1]).Defence, shopList[input - 1].Price, ((Equipment)shopList[input - 1]).Type);  //ask professor
                        player.AddItemToInventory(newItem);
                    }

                    return;
                }

                

               // Item selectedItem=shopList[input-1];
            } 


        }
    }
}
