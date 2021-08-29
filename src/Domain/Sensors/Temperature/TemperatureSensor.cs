using System.Collections.Generic;
using Domain.Sensors.Shared;

namespace Domain.Sensors.Temperature
{
    public class TemperatureSensor
    {
        public SensorId Id { get; }

        public IList<TemperatureReading> Readings { get; } = new List<TemperatureReading>();
        
        public TemperatureSensor(SensorId id)
        {
            Id = id;
        }
    }
    
}