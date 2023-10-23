int[] A = new int[20];
int[] B = new int[20];
Random random = new Random();

for (int i = 0; i < A.Length; i++)
{
    A[i] = random.Next(888);
}
for (int i = 0; i < B.Length; i++)
{
    B[i] = random.Next(100);
}

Array.Sort(B);
Array.Reverse(B);

foreach (int i in A)
{
    Console.WriteLine(i);
}
foreach (int j in B)
{
    Console.WriteLine(j);
}