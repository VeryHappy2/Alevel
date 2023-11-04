using System.Xml.Linq;

namespace Module2_HW3.Candies.Сherry_candies
{
    public class CherryCandies : Candies
    {
        public int cherryCandiesGram = 20;
    }
    public class Kirsh : CherryCandies
    {
        public Kirsh() 
        {
            Name += "Kirsh";
            resultgram += cherryCandiesGram;
        }
    }
    public class CherryFountain : CherryCandies
    {
        public CherryFountain()
        {
            Name += "CherryFountain";
            resultgram += cherryCandiesGram;
        }
    }
}
