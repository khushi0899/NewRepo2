using System;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestProject
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(
            ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            int expectedResult = 200;
            int actualResult;
            int x = 100, y = 2;

            actualResult= x * y;

            _testOutputHelper.WriteLine($"input values are {x} and {y}");
            _testOutputHelper.WriteLine($"expectedResult = {expectedResult}, ActualResult = {actualResult}");

            // ASSERT
            Assert.Equal(expectedResult, actualResult);


        }
    }
}
