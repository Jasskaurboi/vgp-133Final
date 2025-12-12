using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Town
    {
        public void RunScene(Player player)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Choose Menu Option:");
                Console.WriteLine("1. Visit the inn");
                Console.WriteLine("2. Buy consumable");
                Console.WriteLine("3. Buy equipment");
                Console.WriteLine("4. Show inventory");
                Console.WriteLine("5. Display Stats");
                Console.WriteLine("6. Exit");


                int input = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (input)
                {
                    case 1:
                        Console.WriteLine("You visited the inn and healed!");
                        player.UpdateHealth(player.MaxHP);
                        break;
                    case 2:
                        Shop shop1 = new Shop();
                        shop1.RunScene(player, "consumable");
                        break;
                    case 3:
                        Shop shop2 = new Shop();
                        shop2.RunScene(player, "equipment");
                        break;
                    case 4:
                        player.ShowInventory();
                        break;
                    case 5:
                        player.DisplayStats();
                        break;
                    case 6:
                        return;
                    default:
                        break;
                }

                Console.ReadKey();//stop and don't do anything & waiting for you to click somethinhg

            }
        }
    }
}
