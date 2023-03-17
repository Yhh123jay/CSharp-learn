using System;
using Xunit;
using DIP_Units;

namespace DIP_Units.Tests
{
    public class FanTests
    {
        [Fact]
        public void Test1()
        {
            Fan fan = new Fan(new PowerSupplyZero());
            var expected = 0;
            var actual = fan.Work();
            Assert.Equal(expected, actual);
        }
    }

    class PowerSupplyZero : IPowerSupply
    {
        public int GetPower()
        {
            return 0;
        }
    }
}
