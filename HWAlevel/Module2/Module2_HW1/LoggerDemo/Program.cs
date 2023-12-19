namespace LoggerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Logger.WriteLogger("Woah, there was an error");
            Starter starter = new Starter();
            Starter.Run();
        }
    }
}