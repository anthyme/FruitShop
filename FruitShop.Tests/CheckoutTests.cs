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
            Test(checkout, "Mele, Apples, Apples, Mele", 200);
            Test(checkout, "Bananes", 150);
            Test(checkout, "Mele, Apples, Apples, Pommes, Mele", 150);
        }

        [Test]
        public void Iteration5Verifications()
        {
            var checkout = new Checkout();
            Test(checkout, "Mele, Apples, Apples, Pommes, Mele", 100);
            Test(checkout, "Bananes", 250);
        }
    }
}
