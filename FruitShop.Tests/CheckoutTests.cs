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
        public void Iteration5Test()
        {
            var checkout = new Checkout();
            Test(checkout, "Mele, Apples, Apples, Pommes, Apples, Mele, Cerises, Cerises, Bananes", 680);
        }

        [Test]
        public void Iteration5Verifications()
        {
            var checkout = new Checkout();
            Test(checkout, "Cerises, Apples", 175);
            Test(checkout, "Cerises", 230);
            Test(checkout, "Apples, Pommes, Bananes", 580);
            Test(checkout, "Apples, Pommes", 680);
            Test(checkout, "Mele", 780);
            Test(checkout, "Pommes", 880);
        }
    }
}
