using System.Text;
Random random = new Random();

try
{
    Console.WriteLine("Welcome to \"GameMath\"");
    Console.WriteLine("Please choice 2 players or 1 players?");
    Console.WriteLine("Please write \"2 players\" or \"1 player\"");

    string choice = Console.ReadLine();

    Console.WriteLine("Please write.Until what will be numbers the first and second?");

    int firstnumber = Convert.ToInt32(Console.ReadLine()); // first number random
    int secondnumber = Convert.ToInt32(Console.ReadLine()); // second number random

    Console.WriteLine("How many examples?");

    int rounds = Convert.ToInt32(Console.ReadLine());
    int times = 0;
    Console.Clear();
    if (choice == "2" || choice == "Two")
    {
        int playerScore = 0;

        Console.WriteLine("What is name \"player1\" ? ");
        string player1Name = Console.ReadLine();
        Console.WriteLine("What is name \"player2\" ? ");
        string player2Name = Console.ReadLine();
        Console.Clear();

        while (times > rounds)
        {


            char[] operators = { '*', '/', '-', '+' };

            double number = random.Next(firstnumber);
            double number2 = random.Next(secondnumber);

            int randomindex = random.Next(operators.Length);
            char specialoperator = operators[randomindex];

            Console.WriteLine($"Result of the operation: {number} {specialoperator} {number2}");

            double resultplayer1 = CulcaluteAnswer(number, specialoperator, number2);
            double answerPlayer1 = Convert.ToDouble(Console.ReadLine());

            if (specialoperator == '/')
            {

                while (number2 == 0)
                {
                    number2 = random.Next(secondnumber);
                }

            }
            int score = 1;
            int player1Score = 0;
            if (answerPlayer1 == resultplayer1)
            {
                Console.WriteLine($"Well done {player1Name}! ");
                player1Score += score;
                times++;
                continue;
            }
            else
            {
                Console.WriteLine($"Next time will right! Answer is: {resultplayer1}");
                continue;
            }
            number = random.Next(firstnumber);
            number2 = random.Next(secondnumber);

            double answerPlayer2 = Convert.ToDouble(Console.ReadLine());
            double resultPlayer2 = CulcaluteAnswer(number, specialoperator, number2);
            int player2Score = 0;

            if (answerPlayer2 == resultPlayer2)
            {
                Console.WriteLine($"Well done {player2Name}!");
                player2Score += score;
                times++;
                continue;
            }
            else
            {
                Console.WriteLine($"Next time will right! Answer is: {resultPlayer2}");
            }

            Console.WriteLine($"{player1Name} has score: {player1Score}");
            Console.WriteLine($"{player2Name} has score: {player2Score}");

            if (player1Score > player2Score)
            {
                Console.WriteLine($"Winner is {player1Name}");
            }
            else if (player1Score < player2Score)
            {
                Console.WriteLine($"Winner is {player2Name}");
            }
            else { Console.WriteLine("Neither of the players is winner"); }
        }
    }
    else if (choice == "1 player")
    {
        while (times > rounds)
        {
            char[] operators = { '*', '/', '-', '+' };
            times++;

            double number = random.Next(firstnumber);
            double number2 = random.Next(secondnumber);

            int randomindex = random.Next(operators.Length);
            char specialoperator = operators[randomindex];

            if (specialoperator == '/')
            {
                while (number2 == 0)
                {
                    number2 = random.Next(secondnumber);
                }

            }

            Console.WriteLine($"Result of the operation: {number} {specialoperator} {number2}");

            double result = CulcaluteAnswer(number, specialoperator, number2);
            double answer = Convert.ToDouble(Console.ReadLine());

            if (answer == result)
            {
                Console.WriteLine("Well done!");
                continue;
            }
            else
            {
                Console.WriteLine($"Next time will right! Answer is: {result}");
            }
        }
    }
}
catch (FormatException)
{
    Console.WriteLine("Error");
}
static double CulcaluteAnswer(double number, char specialoperator, double number2)
{
    switch (specialoperator)
    {
        case '*':
            return (number * number2); //*
        case '-':
            return (number - number2); //- 
        case '+':
            return (number + number2); //+
        case '/':
            return (number / number2);
        default:
            throw new FormatException("Invalid operator");
    }
}