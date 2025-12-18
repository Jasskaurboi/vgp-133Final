namespace ConsoleApp1
{
    public class GameManager
    {
        private Player player = null;

        public Player Player { get { return player; } }

        public void Newgame()
        {
            //player = new Player(); for testing 
            CreatePlayer();
        }

        public void Continue()
        {

        }

        public void RunGame()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Over World!!");
                Console.WriteLine($"{player.CurrentHP}/{player.MaxHP}hp | {player.Gold}g");

                Console.WriteLine("Choose Menu Option:");
                Console.WriteLine("1. Town");
                Console.WriteLine("2. Forest");
                Console.WriteLine("3. Mountain");
                Console.WriteLine("4. Boss Castle");
                Console.WriteLine("5. Save");
                Console.WriteLine("6. Load");
                Console.WriteLine("7. Exit");

                int input = -1;
                if (int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= 7)
                {

                }
                else
                {
                    continue;
                }
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
                        if (player.IsGameOver)
                        {
                            return;
                        }
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

        }

        private void CreatePlayer()
        {
            string name;
            string hairColour;
            string gender;
            int age;

            Console.WriteLine("Enter the name:");
            string input = Console.ReadLine();
            name = input;

            Console.WriteLine("Enter the Hair colour:");
            input = Console.ReadLine();
            hairColour = input;

            Console.WriteLine("Enter the gender:");
            input = Console.ReadLine();
            gender = input;

            Console.WriteLine("Enter the age:");
            int ageInput = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out ageInput) && ageInput >= 18 && ageInput < 99)
                {
                    break;
                }
            }
            age = ageInput;

            player= new Player(name, hairColour,gender,age);

        }


        private void Save()
        {

        }

        private void Load()
        {

        }


    }

}
