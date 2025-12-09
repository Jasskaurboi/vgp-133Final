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

            Console.Clear();
            Console.WriteLine("Choose Menu Option:");
            Console.WriteLine("1. New game");
            Console.WriteLine("2. Continue");
            Console.WriteLine("3. Exit");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1: 
                    player.UpdateHealth(player.MaxHP);
                    break;
                case 2:
                    Shop shop1= new Shop();
                    shop1.RunScene(player, "consumable");
                    break;
                case 3:
                    Shop shop2= new Shop();
                    shop2.RunScene(player, "equipment");
                    break;
                case 4:
                    player.ShowInventory();
                    break;
                case 5:
                    return;
                default:
                break;
            }
        }
    }
}
