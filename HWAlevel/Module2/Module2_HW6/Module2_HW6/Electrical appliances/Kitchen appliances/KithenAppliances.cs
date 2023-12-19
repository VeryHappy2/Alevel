using Module2_HW6.Abstractions;

namespace Module2_HW6.Electrical_appliances.Kitchen_appliances
{
    public class KithenAppliances : Characteristics
    {
        public KithenAppliances()
        {
            ElectricalAppliances += "Oven, microwave oven";
            Power += 4;
        }
    }
}
