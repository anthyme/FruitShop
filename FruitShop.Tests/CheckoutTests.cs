using FluentAssertions;
using NUnit.Framework;

namespace FruitShop.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private void Test(Checkout checkout, string input, int result)
        {
            var output = checkout.Add(input);
            int.Parse(output).Should().Be(result);
        }

        [Test]
        public void Iteration1Test()
        {
            var checkout = new Checkout();
            Test(checkout, "Pommes", 100);
            Test(checkout, "Cerises", 175);
            Test(checkout, "Cerises", 250);
        }

        [Test]
        public void Iteration1Verifications()
        {
            var checkout = new Checkout();
            Test(checkout, "Cerises", 75);
            Test(checkout, "Pommes", 175);
            Test(checkout, "Cerises", 250);
            Test(checkout, "Bananes", 400);
            Test(checkout, "Pommes", 500);
        }
    }
}
