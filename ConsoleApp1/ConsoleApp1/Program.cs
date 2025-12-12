using ConsoleApp1;

while (true)
{
    GameManager gameManager = new GameManager();

    Console.Clear();
    Console.WriteLine("Choose Menu Option:");
    Console.WriteLine("1. New game");
    Console.WriteLine("2. Continue");
    Console.WriteLine("3. Exit");
    int input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {
        case 1:
            gameManager.Newgame(); // Start new game
            break;
        case 2:
            gameManager.Continue(); // Load saved game
            break;
        case 3:
            return; // Exit the game
        default:
            break;
    }


    if(gameManager.Player != null)
    {
        gameManager.RunGame();


    }
}