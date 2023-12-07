using System;
using System.Threading;
using System.Threading.Tasks;

namespace HW5
{
    internal sealed class Program
    {
        private delegate void MyDelegate (State newState);
        private event MyDelegate myEvent;

        private State ranState { get; set; }
        static async Task Main()
        {            
            var program = new Program();
            await program.Open();
        }
        public async Task Open()
        {
            myEvent += MyMethod;
            var source = new CancellationTokenSource();
            CancellationToken cancellation = source.Token;

            Console.CancelKeyPress += (sender, e) =>
            {
                source.Cancel();
            };

            cancellation.Register(
                () => Console.WriteLine("window was closed by the user"));         

            while (!cancellation.IsCancellationRequested) 
            {
                myEvent?.Invoke(ranState);
                Console.WriteLine($"Event: {ranState}");
                Console.WriteLine("window is open");
                await Task.Delay(3000);
            }


        }

        public void MyMethod(State newState)
        {
            Random random = new Random();
            var values = Enum.GetValues(typeof(State));
            ranState = (State)values.GetValue(random.Next(values.Length));

        }

    }
}
