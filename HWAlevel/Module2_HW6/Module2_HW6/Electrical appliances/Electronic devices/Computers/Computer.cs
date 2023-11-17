using Module2_HW6.Abstractions;

namespace Module2_HW6.Electrical_appliances.Electronic_devices.Abstract
{
    public class Computer : ElectricBase
    {
        public Computer()
        {
            power = 2;
            name = "Computer";
        }
    }
}