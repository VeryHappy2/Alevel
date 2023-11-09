using Module2_HW4.Program.Intarfaces;
using Module2_HW4.Program.Logger;
using Module2_HW4.Program.Vegetables;

namespace Module2_HW4.Program.Salads
{
    public class GreekSalad : Beginning, ISalads
    {
        List<Vegatables> listGreekSalad = new List<Vegatables>();
        List<string> requiredVegetableGreek = new List<string> { "tomatoes", "pell pepper", "onion", "adyghe cheese", "olives" };
        private string _answerUser = "";
        VegetablesReturn returnvegie = new VegetablesReturn();
   
        public void CreatSalad()
        {
            
            try
            {
                if (answerUserSalad == "greek salad" || answerUserSalad == "greek")
                {

                    isDone = false;
                    int collectedProducts = 0;
                    while (!isDone)
                    {
                        Console.WriteLine("\"1\" if you want will join vegetables to the salad \n\"2\" if you want to delete in the salad ");
                        string answer = Console.ReadLine().ToLower();
                        _answerUser = answer;

                        if (_answerUser == "1")
                        {

                            Console.WriteLine("What it's constist of the \"GreekSalad\"?" +
                            "There're products: potatoes, beet, herring, onion, carrots, tomatoes, pell pepper, olives, adyghe cheese.");

                            string createGreekSalad = Console.ReadLine().ToLower();

                            Vegatables vegetables = returnvegie.AnswerUser(createGreekSalad);
                            vegetables.ICharacteristicVegatebles();

                            listGreekSalad.Add(vegetables);
                            collectedProducts += 1;

                            foreach (Vegatables item in listGreekSalad)
                            {
                                Console.WriteLine($"Gram: {item.resultGram}.\n" +
                                $"Name: {item.Name}.");
                            }

                            if (collectedProducts >= 5)
                            {
                                bool allRequiredVegetablesCollectedGreek = requiredVegetableGreek.All(veggie =>
                                listGreekSalad.Any(item => item.Name == veggie));

                                if (allRequiredVegetablesCollectedGreek)
                                {
                                    Console.WriteLine("Well done!");
                                }
                                else
                                {
                                    Console.WriteLine("You haven't made the salad");
                                }
                                isDone = true;
                            }


                        }
                        else
                        {
                            Console.WriteLine("Invalid name vegetable.");
                        }
                        RemoveVegetables();

                    }
                }
            }
            catch (Exception ex) 
            {
                Log.WriteLogger($"{ex.Message}");
            }

            
        }
        public void RemoveVegetables()
        {
            if (_answerUser == "2")
            {
                Console.WriteLine("What do you took?");
                string vegetablesFromSalad = Console.ReadLine();
                Vegatables vegetablesToRemove = listGreekSalad.FirstOrDefault(c => c.Name == vegetablesFromSalad);

                if (vegetablesToRemove != null)
                {
                    listGreekSalad.Remove(vegetablesToRemove);
                    Console.WriteLine($"You took from salad: {vegetablesToRemove}");
                }
                else
                {
                    Console.WriteLine("Invalid name");
                }
            }
        }
    }
}
