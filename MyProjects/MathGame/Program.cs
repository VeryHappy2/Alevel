Random random = new Random();
try
{
    Console.WriteLine("Please write.Until what will be numbers the first and second?");

    int firstnumber = Convert.ToInt32(Console.ReadLine()); // first number random
    int secondnumber = Convert.ToInt32(Console.ReadLine()); // second number random



    Console.WriteLine("How many examples?");
    int examples = Convert.ToInt32(Console.ReadLine());
    int time = 0;
    while (time < examples)
    {
        char[] operators = { '*', '/', '-', '+' };
        time++;

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

        double result = Answer(number, specialoperator, number2);
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
catch (FormatException)
{
    Console.WriteLine("Error");
}
double Answer(double number, char specialoperator, double number2)
{
    switch (specialoperator)
    {
       case '*':
          return number * number2; // *
       case '-':
          return number - number2; //- 
       case '+':
          return number + number2; //+
       case '/':  
          return Math.Round(number / number2); 
       default:
          throw new FormatException("Invalid operator");
    }
}