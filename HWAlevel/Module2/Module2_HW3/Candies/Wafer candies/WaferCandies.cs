using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW3.Candies.Wafer_candies
{
    public class WaferCandies : Candies
    {
        public int waferCandiesGram = 25;
    }
    public class KitKat : WaferCandies
    {
        public KitKat()
        {
            Name += "KitKat";
            resultgram += waferCandiesGram;
        }
    }
    public class Snickers : WaferCandies
    {
        
        public Snickers()
        {
            resultgram += waferCandiesGram;
            Name += "Snickers";
            
        }
    }
}
