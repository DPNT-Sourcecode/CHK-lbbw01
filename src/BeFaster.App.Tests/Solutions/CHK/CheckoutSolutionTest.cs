using BeFaster.App.Solutions.CHK;
using BeFaster.App.Solutions.SUM;

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
        public int ComputeSum(string? skus)
        {
            return new CheckoutSolution().Checkout(skus);
        }
    }
}

