using BeFaster.App.Solutions.CHK;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    internal class CheckoutSolutionTest
    {
        [TestCase(null, ExpectedResult = -1)]
        [TestCase("ABCD", ExpectedResult = 115)]
        [TestCase("ABBB", ExpectedResult = 125)]
        [TestCase("CAAAAACD", ExpectedResult = 285)]
        [TestCase("BADABCAB", ExpectedResult = 240)]
        [TestCase("BADA123BCAB", ExpectedResult = -1)]
        [TestCase("amsdf", ExpectedResult = -1)]
        [TestCase(" ,.`!#", ExpectedResult = -1)]
        public int ComputeCheckout(string? skus)
        {
            return new CheckoutSolution().Checkout(skus);
        }
    }
}
