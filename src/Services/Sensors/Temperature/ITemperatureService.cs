using System.Collections.Generic;
using Domain.Sensors.Shared;
using Domain.Sensors.Temperature;

namespace Services.Sensors.Temperature
{
    public interface ITemperatureService
    {
        TemperatureReading GetLastReadingFromSensor(SensorId id);
        IEnumerable<TemperatureReading> GetAllReadingsFromSensor(SensorId id);
    }
}