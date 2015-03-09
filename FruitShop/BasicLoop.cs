using System;

namespace FruitShop
{
    public class BasicLoop
    {
        private readonly Checkout _checkout = new Checkout();

        public void Loop()
        {
            String input;
            Console.WriteLine("> ");

            while ((input = Console.ReadLine()) != null)
            {
                Console.WriteLine(DoSomethingWithInput(input));
                Console.WriteLine("> ");
            }
        }

        public string DoSomethingWithInput(string input)
        {
            return _checkout.Add(input);
        }
    }
}