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
        public void Iteration3Test()
        {
            var checkout = new Checkout();
            Test(checkout, "Cerises", 75);
            Test(checkout, "Cerises", 120);
            Test(checkout, "Bananes", 270);
            Test(checkout, "Bananes", 270);
        }

        [Test]
        public void Iteration3Verifications()
        {
            var checkout = new Checkout();
            Test(checkout, "Cerises", 75);
            Test(checkout, "Pommes", 175);
            Test(checkout, "Cerises", 220);
            Test(checkout, "Bananes", 370);
            Test(checkout, "Pommes", 470);
            Test(checkout, "Bananes", 470);
            Test(checkout, "Cerises", 545);
        }
    }
}
