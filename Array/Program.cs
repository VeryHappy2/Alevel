int[] N = {1, 2 , 3 ,5, 4, 5, 105 };

int numbers = 0;

for (int i = 0; i < N.Length; i++)
{
    if (N[i] >= -100 && N[i] <= 100)
    {
        numbers++;
    }
}
Console.WriteLine(numbers);
