namespace ConsoleApp1
{
    public class GameManager
    {
        private Player player = null;

        public Player Player { get { return player; } }

        public void Newgame()
        {
            player = new Player();
        }

        public void Continue()
        {

        }

        public void RunGame()
        {

            Console.Clear();
            Console.WriteLine("Choose Menu Option:");
            Console.WriteLine("1. New game");
            Console.WriteLine("2. Continue");
            Console.WriteLine("3. Exit");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1: // Town
                Town town = new Town();
                    town.RunScene(player);
                    break;
                case 2://Forest
                    Forest forest = new Forest();
                    forest.RunScene(player);
                    break;
                case 3://Mountain
                    Mountain mountain = new Mountain();
                    mountain.RunScene(player);
                    break;
                case 4://BossCastle
                    BossCastle bosscastle = new BossCastle();
                    bosscastle.RunScene(player);
                    break;
                case 5://save
                    Save();
                    break;
                case 6://load
                    Load();
                    break;
                case 7://Exit
                    return;
                default:
                    break;
            }
        }

        private void Save()
        {

        }

        private void Load()
        {

        }


    }

}
