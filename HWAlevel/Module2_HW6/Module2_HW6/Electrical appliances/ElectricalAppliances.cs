using Module2_HW6.Abstractions;

namespace Module2_HW6.Electrical_appliances
{
    public class ElectricalAppliances : Characteristics
    {
        public ElectricalAppliances()
        {
            ElectricalAppliances += "Electric tools, electronic devices, kitchen appliances";
            Power += 18;
        }
    }
}