using ExampleAPI.Controllers;
using System;
using Xunit;

namespace ExampleAPITest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var SUT = new WeatherForecastController(null);
            var getStuff = SUT.Get();
            Assert.True(true);

        }
    }
}
