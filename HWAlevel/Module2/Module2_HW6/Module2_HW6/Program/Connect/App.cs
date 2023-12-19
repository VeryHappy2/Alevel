using Module2_HW6.Abstractions;
using Module2_HW6.Electrical_appliances;
using Module2_HW6.Logger;

namespace Module2_HW6.Program.Connect
{
    public class App
    {
        public bool isDone = false;
        public string answer = "";
        public List<Characteristics> connections = new List<Characteristics>();
        public void Start()
        {

            try
            {
                while (!isDone)
                {
                    AnswerToUser answerToUser1 = new AnswerToUser();
                    ConnectDevices connectDevices = new ConnectDevices();
                    Console.WriteLine("1 - Start\n2 - Exit");
                    string answerStartGame = Console.ReadLine();

                    if (answerStartGame == "1")
                    {
                        Console.WriteLine("What you electrical appliances to connect?\n1 - scroll \n2 - connect all electrical appliances ");
                        answer = Console.ReadLine();
                        
                        if(answer == "1")
                        {
                            answer = String.Empty;
                            answerToUser1.AnswerToUserServices();
                        }
                        
                        ///connectDevices.ConnectServices();

                        if (answer == "2")
                        {
                            Characteristics answerToUser = ConnectInApp(answer);
                            connections.Add(answerToUser);
                            foreach (Characteristics item in connections)
                            {
                                Console.WriteLine($"Connect: {item.ElectricalAppliances}\nPower is using {item.Power}");
                                isDone = true;
                            }
                        }
                    }
                    else if (answerStartGame == "2")
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLogger(ex.Message);
            }


        }
        private Characteristics ConnectInApp(string answerUser)
        {
            switch (answerUser)
            {
                case "2":
                    return new ElectricalAppliances();
                default:
                    throw new Exception("Invalid input for ConnectAll");
            }
        }

    }
}
