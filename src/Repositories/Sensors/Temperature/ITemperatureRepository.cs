using System.Collections.Generic;
using Domain.Sensors.Shared;
using Domain.Sensors.Temperature;

namespace Repositories.Sensors.Temperature
{
    public interface ITemperatureRepository
    {
        TemperatureReading GetLastReadingFromSensor(SensorId id);
        IEnumerable<TemperatureReading> GetAllReadingsFromSensor(SensorId id);
    }
}