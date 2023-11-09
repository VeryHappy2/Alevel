namespace Module2_HW4.Program.Vegetables
{
    public class VegetablesReturn
    {
        public Vegatables AnswerUser(string answerUser)
        {
            switch (answerUser)
            {
                case "tomatoes":
                    return new Tomatoes();
                case "onion":
                    return new Onion();
                case "pell pepper":
                    return new PellPepper();
                case "olives":
                    return new Olives();
                case "adyghe cheese":
                    return new AdygheСheese();
                case "carrots":
                    return new Carrots();
                case "potatoes":
                    return new Potatoes();
                case "beet":
                    return new Beet();
                case "herring":
                    return new Herring();
                default:
                    return null;
            }
        }
    }
}
