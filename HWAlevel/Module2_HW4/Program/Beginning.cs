using Module2_HW4.Program.Intarfaces;
using Module2_HW4.Program.Logger;
using Module2_HW4.Program.Salads;

namespace Module2_HW4.Program
{
    public class Beginning : IBeginning
    {
        public bool isDone = false;
        public string answerUserStart = "";
        protected string answerUserSalad = "";
        public void Start()
        {

            try
            {
                while (!isDone)
                {

                    

                    Console.WriteLine("1 Start \n2 Exit");
                    string answerStartGame = Console.ReadLine();
                    answerUserStart = answerStartGame;

                    if (answerUserStart == "1")
                    {
                        Console.WriteLine("What will you cook salad (\"Greek Salad\" \"Herring Salad\")?");
                        string answerSalad = Console.ReadLine().ToLower();
                        isDone = true;
                        answerUserSalad = answerSalad;
                        

                    }
                    else if (answerStartGame == "2")
                    {
                        isDone = true;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                Log.WriteLogger($"{ex.Message}");
            }
            

        }




        
    }  
}
