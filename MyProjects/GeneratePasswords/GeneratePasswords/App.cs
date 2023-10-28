using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace GeneratePasswords
{
    internal class App
    { 
        
        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string listNumbers = "0123456789";
        private const string specialChars = "!@#$%^&*()_+-=[]{}|;:'\"<>,.?/";

        private string generatePassword = "";

        public void StartProgram()
        {
            Console.WriteLine("Welcome to \"GeneratePassword\".\n1 Start \n2 Exit");
            string answer = Console.ReadLine();
            bool useAnswer = answer == "1";

            if (useAnswer)
            {
                try
                {
                    generatePassword = Password();
                    WriterPassword(generatePassword);
                }
                catch (Exception ex) {  Console.WriteLine($"Error: {ex.Message}"); }  
                

            }
            else if( answer != "1" || answer != "2" ) { Console.WriteLine("Error");  }
        }
        
        public string Password() 
        {
           
            
                StringBuilder password = new StringBuilder();

                Console.WriteLine("How long is the password?");
                string lenghts = Console.ReadLine();
                int passwordLength = int.Parse(lenghts);

                Console.WriteLine("Password has special symbols? (yes / no)");
                string specialOperators = Console.ReadLine().Trim();
                bool useSpecial = specialOperators.ToLower() == "yes";

                Console.WriteLine("Password using the numbers? (yes / no)");
                string numbers = Console.ReadLine().Trim();
                bool useNumbers = specialOperators.ToLower() == "yes";

                Console.WriteLine("Password using lowercase letters? (yes / no)");
                string lowerCaseLetters = Console.ReadLine().Trim();
                bool useLowerLetters = specialOperators.ToLower() == "yes";

                Console.WriteLine("Password using capital letters? (yes / no)");
                string upperLetters = Console.ReadLine().Trim();
                bool useUpperLetters = specialOperators.ToLower() == "yes";

                string List = "";

                if (useLowerLetters)
                {
                    List += Lowercase;
                }

                if (useUpperLetters)
                {
                    List += Uppercase;
                }
                if (useNumbers)
                {
                    List += listNumbers;
                }

                if (useSpecial)
                {
                    List += specialChars;
                }

                for (int i = 0; i < passwordLength; i++)
                {
                    Random random = new Random();

                    int index = random.Next(List.Length);

                    password.Append(List[index]);
                }

                string generatePassword = password.ToString();
                return generatePassword;                                 
        }
        public static void WriterPassword(string generatedPassword)
        {
            try
            {
                string logPath = ConfigurationManager.AppSettings["logPath"];
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"Password: {generatedPassword}");
                }
            }
            catch (Exception ex) { Console.WriteLine("Error:" + ex.Message); }
            
            
        }
    }
           
}

