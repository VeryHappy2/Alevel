using Module2_HW3.Candies.Wafer_candies;
using Module2_HW3.Candies.Сherry_candies;
using Module2_HW3.Candies.Сhoclats_candies;

namespace Module2_HW3.Candies.Program
{
    internal class Program
    {
        static void Main()
        {

            try
            {
                Console.WriteLine("How did candies bought?");

                List<Candies> basket = new List<Candies>();
                List<Candies> takeAway = new List<Candies>();

                while (true)
                {
                    Console.Write("'1' Start: \n'2' Take candies: \n'3' To exit:\n ");
                    string answer = Console.ReadLine();                    

                    if (answer == "1")
                    {


                        Console.WriteLine($"Please put as a gift сandies (\"KitKat\", \"Snickers\", \"Kirsh\", \"CherryFountain\", \"FerreroRocher\", \"LintLindor\")");
                        string putGift = Console.ReadLine();

                        Candies candy = CreateCandyByName(putGift);

                        basket.Add(candy);
                        Console.WriteLine("Gift:");
                        foreach (Candies candy1 in basket)
                        {
                            Console.WriteLine($"{candy1.Name}.It's has {candy1.resultgram} gram");
                        }

                        if (candy == null)
                        {
                            Console.WriteLine("Invalid candy name. Please try again.");
                        }

                    }

                    if (answer == "3")
                    {
                        break;
                    }

                    if (answer == "2")
                    {
                        try
                        {
                            foreach (Candies candy1 in basket)
                            {
                                Console.WriteLine($"Will take candies from a gift {candy1.Name} ");
                            }

                            string candiesFromGift = Console.ReadLine();

                            Candies candyToRemove = basket.FirstOrDefault(c => c.Name == candiesFromGift);

                            if (candyToRemove != null)
                            {

                                basket.Remove(candyToRemove);
                                Console.WriteLine($"You took from a gift: {candyToRemove.Name}");
                                takeAway.Add(candyToRemove);
                            }
                            else
                            {
                                Console.WriteLine("Invalid candy name. Please try again.");
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }


                    }



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public static Candies CreateCandyByName(string name)
        {
            switch (name)
            {
                case "KitKat":
                    return new KitKat();
                case "Snickers":
                    return new Snickers();
                case "Kirsh":
                    return new Kirsh();
                case "CherryFountain":
                    return new CherryFountain();
                case "FerreroRocher":
                    return new FerreroRocher();
                case "LintLindor":
                    return new LintLindor();
                default:
                    return null;
            }
        }
    }
}
