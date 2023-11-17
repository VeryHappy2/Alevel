using Module2_HW6.Abstractions;
using System.Xml.Linq;

namespace Module2_HW6.Electrical_appliances.Kitchen_appliances
{
    public class Oven : ElectricBase
    {
        public Oven()
        {
            name = "MicrowaveOven";
            power = 2;
        }   
    }
}
