Random random = new Random();

Console.WriteLine("Hello! Would you like to play my game?");
var player1 = Console.ReadLine();

if (player1.ToLower() == "Yes")
{
    var bot = random.Next(50);
    Console.Clear();
    int attempts = 0;
    while (true)
    {
        Console.WriteLine("Pls  write a number");
        var player = Console.ReadLine();
        attempts++;
        if (int.TryParse(player, out int player2))
        {
            Console.Clear();
            if (player2 < bot)
            {
                Console.WriteLine("My number is higher");
            }
            else if (player2 > bot)
            {
                Console.WriteLine("My number is less");
            }
            else
            {
                Console.WriteLine($"Very Good! Number was {bot}. You made {attempts} attempts ");
                break;
            }

        }
        else
        {
            Console.WriteLine("Write correctly pls");
        }


    }
}
else if (player1 == "No")
{
    Console.WriteLine("Ehhh...I want to play with you");
}
else
{
    Console.WriteLine("Error: pls try again");
}