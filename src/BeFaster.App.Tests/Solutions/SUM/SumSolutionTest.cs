using BeFaster.App.Solutions.SUM;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.SUM
{
    [TestFixture]
    public class SumSolutionTest
    {
        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(5, 10, ExpectedResult = 15)]
        [TestCase(10, 5, ExpectedResult = 15)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(100, 100, ExpectedResult = 200)]
        public int ComputeSum(int x, int y)
        {
            return new SumSolution().Sum(x, y);
        }
    }
}

