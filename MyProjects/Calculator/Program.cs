using System;

while (true)
{
    Console.WriteLine("Please write first number, + or / or * and second number");

    if (!double.TryParse(Console.ReadLine(), out double number1) ||
    !char.TryParse(Console.ReadLine(), out char a) ||
    !double.TryParse(Console.ReadLine(), out  double number2))
    {
        Console.WriteLine("Please write valid numbers.");
        break;
    }
    double result = 0;

    switch (a)
    {
        case '+':
            result = number1 + number2;
            break;
        case '-':
            result = number1 - number2;
            break;
        case '*':
            result = number1 * number2;
            break;
        case '/':
            if (number1 == 0 || number2 == 0)
            {
                Console.WriteLine("Error: number is 0");
                break;

            }
            result = number1 / number2;
            break;
        default:
            Console.WriteLine("Please use *,/,+,-");
            break;

    }
    Console.WriteLine($"Result: {result:F2}");
    Console.WriteLine("Would you want continue?");
    string answer = Console.ReadLine();
    
    if (answer == "no")
    {
        break;
    }
    else if ( answer == "yes" ) 
    {
        continue;
    }
}

