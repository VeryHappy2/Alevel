using Module2_HW4.Program.Intarfaces;
using Module2_HW4.Program.Logger;

namespace Module2_HW4.Program
{
    public class Beginning : IBeginning
    {
        public bool isDone = true;
        public string answerUserStart = "";
        public string answerUserSalad = "";
        public void Start()
        {

            try
            {
                while (isDone)
                {

                    

                    Console.WriteLine("1 Start \n2 Exit");
                    string answerUserStart = Console.ReadLine();

                    if (answerUserStart == "1")
                    {
                        Console.WriteLine("What will you cook salad (\"Greek Salad\" \"Herring Salad\")?");
                        answerUserSalad = Console.ReadLine().ToLower();
                        isDone = false;
                        

                    }
                    else if (answerUserStart == "2")
                    {
                        isDone = false;
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
