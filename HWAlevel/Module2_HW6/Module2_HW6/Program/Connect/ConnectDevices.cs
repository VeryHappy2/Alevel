using Module2_HW6.Abstractions;
using Module2_HW6.Electrical_appliances.Electric_tools;
using Module2_HW6.Electrical_appliances.Electronic_devices.Abstract;
using Module2_HW6.Electrical_appliances.Electronic_devices.Computers;
using Module2_HW6.Electrical_appliances.Electronic_devices.Phones;
using Module2_HW6.Electrical_appliances.Kitchen_appliances;

namespace Module2_HW6.Program.Connect
{
    public class ConnectDevices : AnswerToUser
    {
        

        public void ConnectServices()
        {
            List<ElectricBase> connectionsItems = new List<ElectricBase>();
            switch (answerGlobal)
            {
                case "4":
                    Console.WriteLine("Tools: \n1 - power drills\n2 - vacuum");
                    string answerToTools = Console.ReadLine();
                    if (answerToTools == "1")
                    {
                        ElectricBase answerTools = ConnectTools(answerToTools);
                        connectionsItems.Add(answerTools);

                        foreach(ElectricBase item in connectionsItems)
                        {
                            foreach (Characteristics item2 in connections)
                            {
                                Console.WriteLine($"Connected items: {item.name}" +
                                    $"\nPower items: {item.power} " +
                                    $"\nConnected: {item2.ElectricalAppliances}" +
                                    $"\nPower: {item2.Power}");
                            }
                            
                        }
                        
                    }
                    break;

                case "5":
                    Console.WriteLine("Devices: \n1 - laptop\n2 - computer");
                    string answerToDevices = Console.ReadLine();
                    if (answerToDevices == "1")
                    {
                        ElectricBase answerUser1 = ConnectDevice(answerToDevices);
                        connectionsItems.Add(answerUser1);
                    }
                    break;
                case "6":
                    Console.WriteLine("Kitchen tools: \n1 - microwave oven\n2 - oven");
                    string answerToKitchen = Console.ReadLine();
                    if (answerToKitchen == "1")
                    {
                        ElectricBase answerUser2 = ConnectKitchen(answerToKitchen);
                        connectionsItems.Add(answerUser2);
                        
                    }
                    break;
            }

        }


        private ElectricBase ConnectTools(string answerTools)
        {
            switch (answerTools)
            {
                case "1":
                    return new PowerDrills();
                case "2":
                    return new Vacuum();
                default:
                    throw new Exception("Don't connect to the \"ConnectTools\"");
            }
        }
        private ElectricBase ConnectDevice(string answerDevices)
        {
            switch (answerDevices)
            {
                case "1":
                    return new Laptop();
                case "2":
                    return new Computer();
                case "3":
                    return new Sumsung();
                case "4":
                    return new Xiomi();
                default:
                    throw new Exception("Don't connect to the \"ConnectTools\"");
            }
        }
        private ElectricBase ConnectKitchen(string answerKitchen)
        {
            switch (answerKitchen)
            {
                case "1":
                    return new MicrowaveOven();
                case "2":
                    return new Oven();
                default:
                    throw new Exception("Don't connect to the \"ConnectTools\"");
            }
        }
    }
}
