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
        public void Iteration4Test()
        {
            var checkout = new Checkout();
            Test(checkout, "Cerises", 75);
            Test(checkout, "Apples", 175);
            Test(checkout, "Cerises", 230);
            Test(checkout, "Bananes", 380);
            Test(checkout, "Bananes", 380);
        }

        [Test]
        public void Iteration4Verifications()
        {
            var checkout = new Checkout();
            Test(checkout, "Cerises", 75);
            Test(checkout, "Apples", 175);
            Test(checkout, "Cerises", 230);
            Test(checkout, "Bananes", 380);
            Test(checkout, "Pommes", 480);
            Test(checkout, "Mele", 580);
        }
    }
}
