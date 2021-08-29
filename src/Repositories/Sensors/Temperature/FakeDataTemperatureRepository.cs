using System;
using System.Collections.Generic;
using Domain.Sensors.Shared;
using Domain.Sensors.Temperature;

namespace Repositories.Sensors.Temperature
{
    public class FakeDataTemperatureRepository : ITemperatureRepository
    {
        private const double Min = -50.0;
        private const double Max = 100.0;
        
        private static double GetRandomDoubleWithMinAndMax() =>
            new Random().NextDouble() * (Max - Min) + Min;

        public TemperatureReading GetLastReadingFromSensor(SensorId id)
        {
            // Fake data.
            return new TemperatureReading(GetRandomDoubleWithMinAndMax(), DateTime.Now);
        }

        public IEnumerable<TemperatureReading> GetAllReadingsFromSensor(SensorId id)
        {
            // Fake data.
            var sensor = new TemperatureSensor(id);
            for (var i = 0; i < 10; i++)
            {
                var fakeTemp = GetRandomDoubleWithMinAndMax();
                var fakeTime = DateTime.Now.AddMinutes(i * -1);
                sensor.Readings.Add(new TemperatureReading(fakeTemp, fakeTime));
            }

            return sensor.Readings;
        }

        
    }
}