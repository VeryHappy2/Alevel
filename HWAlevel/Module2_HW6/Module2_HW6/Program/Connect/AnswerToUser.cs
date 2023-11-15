using Characteristics = Module2_HW6.Abstractions.Characteristics;
using Module2_HW6.Electrical_appliances.Kitchen_appliances;
using Module2_HW6.Electrical_appliances.Electronic_devices;
using Module2_HW6.Electrical_appliances.Electric_tools;

namespace Module2_HW6.Program.Connect
{
    public class AnswerToUser : App
    {
        private int _resultPower = 0;
        private string _resultTools = "";
        public string answerGlobal = "";
        public void AnswerToUserServices()
        {
            ConnectDevices connectDevices = new ConnectDevices();

            while(!isDone)
            {
                Console.WriteLine("What will you connect" +
                   "\n\"1\" - connect all kitchen appliances" +
                   "\n\"2\" - connect all electronic devices" +
                   "\n\"3\" - connect all electric tools" +

                   "\n\n\"4\" - enter into electric tools" +
                   "\n\"5\" - enter into electronic devices" +
                   "\n\"6\" - enter into kitchen appliances" +

                   "\n\n\"7\" - exit");


                answerGlobal = Console.ReadLine();
                 
                connectDevices.ConnectServices();

                if (answer == "1" || answer == "2" || answer == "3")
                {
                    Characteristics answerToUser = ConnectInAnswerToUser(answer);
                    connections.Add(answerToUser);
                    foreach (Characteristics item in connections)
                    {
                        Console.WriteLine($"Connected: {item.ElectricalAppliances} " +
                            $"\nPower is using: {item.Power}");
                        _resultPower += item.Power;
                        _resultTools += item.ElectricalAppliances;
                    }

                    Console.WriteLine($"Power is using: {_resultPower}" +
                        $"\nConnections: {_resultTools}");

                    answer = string.Empty;
                    Console.WriteLine("Would you want continue?\n1 - continue\n2 - exit");
                    answer = Console.ReadLine();

                    if (answer == "1")
                    {
                        continue;
                    }
                    if (answer == "2")
                    {
                        isDone = true;
                    }
                }
            }                                      
        }
        private Characteristics ConnectInAnswerToUser(string answer)
        {
            switch (answer)
            {
                case "1":
                    return new KithenAppliances();
                case "2":
                    return new ElectronicDevices();
                case "3":
                    return new ElectricTools();
                default:
                    throw new Exception("\"Invalid input for ConnectAll\"");
            }
        }
    }
}
