using System;
using System.Diagnostics.Metrics;

internal class Program
{
    static void Main()
    {
        int[] N = new int[26];
        Random random = new Random();
        for (int i = 0; i < N.Length; i++)
        {
            N[i] = random.Next(1, 26);
        }

        List<int> evenArray = new List<int>();
        List<int> oddArray = new List<int>();

        foreach (int num in N)
        {
            if (num % 2 == 0)
            {
                evenArray.Add(num);
            }
            else
            {
                oddArray.Add(num);
            }

        }

        string ConvertToLetters(List<int> numList)
        {

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string result = string.Empty;

            foreach (int num in numList)
            {
                char letter = alphabet[num];
                if ("aeidhj".Contains(letter))
                {
                    result += char.ToUpper(letter);
                }
                else
                {
                    result += letter;
                }
            }
            return result;
        }

        string evenLetters = ConvertToLetters(evenArray);
        string oddLetters = ConvertToLetters(oddArray);

        Console.WriteLine("Array with even letters: " + evenLetters);
        Console.WriteLine("Array with odd letters: " + oddLetters);

        int evenUpper = evenLetters.Count(char.IsUpper);
        int oddUpper = oddLetters.Count(char.IsUpper);

        if (evenUpper > oddUpper) 
        { 
            Console.WriteLine("An array with even letters contains more capital letters."); 
        }
        else if (oddUpper > evenUpper) 
        { 
            Console.WriteLine("An array with odd letters contains more capital letters."); 
        }
        else if (oddUpper == evenUpper) 
        {
            Console.WriteLine("Both arrays contain the same number of capital letters. ");
        }

    }
}
