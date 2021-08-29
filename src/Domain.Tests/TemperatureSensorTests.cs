using System;
using Domain.Sensors.Shared;
using Xunit;

namespace Domain.Tests
{
    public class SensorIdTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void SensorId_Null_ThrowsException(string id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var sensorId = new SensorId(id);
            });
        }
        
        [Theory]
        [InlineData("test")]
        [InlineData("aaa-bbb-ccc")]
        [InlineData("   aaa-bbb-ccc   ")]

        public void SensorId_ValidString_DoesntThrow_AndIsTrimmed(string id)
        {
            var sensorId = new SensorId(id);
            Assert.Equal(id.Trim(), sensorId.Value);
        }
    }
}