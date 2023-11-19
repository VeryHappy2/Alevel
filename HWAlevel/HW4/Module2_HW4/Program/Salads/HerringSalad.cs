using Module2_HW4.Program.Intarfaces;
using Module2_HW4.Program.Logger;
using Module2_HW4.Program.Vegetables;

namespace Module2_HW4.Program.Salads
{
    internal class HerringSalad : Beginning, ISalads
    {
        private string _answerUser = "";
        List<Vegatables> listHerringSalad = new List<Vegatables>();
        List<string> requiredVegetablesHerring = new List<string> { "potatoes", "beet", "herring", "onion", "carrots" };
        VegetablesReturn returnvegie = new VegetablesReturn();

        public void CreatSalad()
        {
            try
            {
                if (answerUserSalad == "herring salad" || answerUserSalad == "herring")
                {

                    isDone = false;
                    int collectedProducts = 0;
                    while (!isDone)
                    {
                        Console.WriteLine("1\" if you want will join vegetables to the \"Herring Salad\" \n\"2\" if you want to delete vegetables in the salad");

                        string createHerriingSalad = Console.ReadLine().ToLower();

                        _answerUser = createHerriingSalad;
                        Vegatables vegetables = returnvegie.AnswerUser(_answerUser);
                        vegetables.ICharacteristicVegatebles();
                        if (vegetables != null)
                        {
                            listHerringSalad.Add(vegetables);
                            collectedProducts += 1;

                            foreach (Vegatables itemHerring in listHerringSalad)
                            {
                                Console.WriteLine($"Gram: {itemHerring.resultGram}.\n" +
                                    $"Name: {itemHerring.Name}");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid name vegetable.");
                        }

                        if (collectedProducts >= 5)
                        {
                            bool allRequiredVegetablesCollectedHerring = requiredVegetablesHerring.All(veggietablesHerring => listHerringSalad.Any(itemHerring => itemHerring.Name == veggietablesHerring));

                            if (allRequiredVegetablesCollectedHerring)
                            {
                                Console.WriteLine("Well done!");
                            }
                            else
                            {
                                Console.WriteLine("You haven't made the salad");
                            }
                            isDone = true;
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
                Vegatables vegetablesToRemove = listHerringSalad.FirstOrDefault(c => c.Name == vegetablesFromSalad);

                if (vegetablesToRemove != null)
                {
                    listHerringSalad.Remove(vegetablesToRemove);
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


