namespace Module2_HW2
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();   

            string[] products = { "tomatoes", "apples", "ice cream", "cookies", "cucambars",
                    "mashrooms", "bananas", "pie", "potatoes", "salad",
                    "meat", "chips", "pastas", "tea", "sausages",
                    "fish", "coffe", "carrots", "juice", "orange",
                    "bread", "chocolate"};
     
            List<string> shoppingCart = new List<string>();
            int[] cartItemIndexes = { 3, 5, 2, 4, 5, 15, 20, 1, 12, 17 };
            foreach (int index in cartItemIndexes) { shoppingCart.Add(products[index]); }

            Console.WriteLine("You placed an order for goods. Products: " + string.Join(", ", shoppingCart));
            int number = random.Next(1000);
            Console.WriteLine("Buyer has placed an order for goods number:" + number);

        }
    }
}