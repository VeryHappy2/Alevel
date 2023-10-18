using System;


char[] array = {'0','1','2','3','4','5','6','7','8'};
int win = 0; // 0 - nothing, 1 - win, -1 - draw
int choice;
int player = 0;
Console.WriteLine("What's name player 1 ");   //IndexOutOfRangeException


void Board()
{
    Console.WriteLine("      |     | ");
    Console.WriteLine($"   {array[0]}  |  {array[1]}  |  {array[2]}");
    Console.WriteLine("______|_____|_____");
    Console.WriteLine("      |     | ");
    Console.WriteLine($"   {array[3]}  |  {array[4]}  |  {array[5]}"); //Board
    Console.WriteLine("______|_____|_____");
    Console.WriteLine("      |     | ");
    Console.WriteLine($"   {array[6]}  |  {array[7]}  |  {array[8]}");
    Console.WriteLine("      |     | ");
}
do
{


    Console.Clear();
    Console.WriteLine("Player 1 - X, player 2 - 0");
    Board();
    try
    {
        if ((array[0] == 'X' && array[1] == 'X' && array[2] == 'X') || // Проверки на победу
        (array[0] == 'O' && array[3] == 'O' && array[6] == 'O') ||
        (array[3] == 'X' && array[4] == 'X' && array[5] == 'X') ||
        (array[1] == 'O' && array[4] == 'O' && array[7] == 'O') ||
        (array[6] == 'X' && array[7] == 'X' && array[8] == 'X') ||
        (array[2] == 'O' && array[5] == 'O' && array[8] == 'O'))
        {
            win = 1;
        }
        else
        {
            win = 0;
        }


        if (player == 8)
        {
            win = -1;
            Console.WriteLine("Draw!");

        }
        else if (player != 8)
        {

            if (player % 2 == 0)
            {
                choice = int.Parse(Console.ReadLine());
                if (array[choice] != 'X' && array[choice] != 'O') // 0
                {
                    array[choice] = 'X';
                    player++;
                }
            }
            else
            {
                choice = int.Parse(Console.ReadLine());
                if (array[choice] != 'X' && array[choice] != 'O') // X
                {
                    array[choice] = 'O';
                    player++;
                }
            }
        }
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Write please the numbers that are on the board");
    }
    

} while (win != 1 && win != -1);
if (win == 1) 
{
    Console.WriteLine($" Player: {player % 2 + 1} win! ");
}
