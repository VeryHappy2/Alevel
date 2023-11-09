using Module2_HW4.Program;

namespace Module2_HW4.Program.Vegetables
{
    public abstract class Vegatables 
    {
        public string Name { get; set; }
        public int Gram { get; set; }

        public int resultGram = 0;

        public const int gramPellPepper = 45;
        public const int gramTomatoes = 25;
        public const int gramOnion = 150;
        public const int gramOlives = 30;
        public const int gramAdygheСheese = 50;
        public const int gramHerring = 200;
        public const int gramCarrots = 105;
        public const int gramBeet = 70;
        public const int gramPotatoes = 85;

        public abstract void ICharacteristicVegatebles();

    }
    public class Tomatoes : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "tomatoes";
            resultGram = Gram + gramTomatoes;
        }
    }
    public class PellPepper : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "pell pepper";
            resultGram = Gram + gramPellPepper;
        }
    }
    public class Onion : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "onion";
            resultGram = Gram + gramOnion;
        }
    }
    public class Olives : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "olives";
            resultGram = Gram + gramOlives;

        }
    }
    public class AdygheСheese : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "adyghe cheese";
            resultGram = Gram + gramAdygheСheese;
        }
    }
    public class Carrots : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "carrots";
            resultGram = Gram + gramCarrots;
        }
    }
    public class Beet : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "beet";
            resultGram = Gram + gramBeet;
        }
    }
    public class Potatoes : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "potatoes";
            resultGram = Gram + gramPotatoes;
        }
    }
    public class Herring : Vegatables
    {
        public override void ICharacteristicVegatebles()
        {
            Name = "herring";
            resultGram = Gram + gramHerring;
        }
    }
}
