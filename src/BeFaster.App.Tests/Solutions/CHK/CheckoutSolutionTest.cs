using BeFaster.App.Solutions.CHK;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    internal class CheckoutSolutionTest
    {
        [TestCase(null, ExpectedResult = -1)]
        [TestCase("ABCD", ExpectedResult = 115)]
        [TestCase("ABBB", ExpectedResult = 125)]
        [TestCase("CAAAAACD", ExpectedResult = 255)]
        [TestCase("BADABCAB", ExpectedResult = 240)]
        [TestCase("EABCD", ExpectedResult = 155)]
        [TestCase("EEBCD", ExpectedResult = 115)]
        [TestCase("EEBCBBDEE", ExpectedResult = 225)]
        [TestCase("BBEEBCD", ExpectedResult = 160)]
        [TestCase("ABCDEF", ExpectedResult = 165)]
        [TestCase("FFF", ExpectedResult = 20)]
        [TestCase("FFFFF", ExpectedResult = 40)]
        [TestCase("FFFFFF", ExpectedResult = 40)]
        [TestCase("BADA123BCAB", ExpectedResult = -1)]
        [TestCase("amsdf", ExpectedResult = -1)]
        [TestCase(" ,.`!#", ExpectedResult = -1)]
        public int ComputeCheckout(string? skus)
        {
            return new CheckoutSolution().Checkout(skus);
        }
    }
}



