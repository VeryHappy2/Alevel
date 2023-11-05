namespace Module2_HW3.Candies.Сhoclats_candies
{
    public class ChocklateCandies : Candies
    {
        public int chocklateCandiesGram = 30;
    }
    public class FerreroRocher : ChocklateCandies
    {
        public FerreroRocher() 
        {
            Name += "FerreroRocher";
            resultgram += chocklateCandiesGram;

        }
    }
    public class LintLindor : ChocklateCandies 
    {
        public LintLindor() 
        {
            Name += "LintLindor";
            resultgram += chocklateCandiesGram;
        } 
    }

}
