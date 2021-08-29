using System;

namespace Domain.Sensors.Temperature
{
    public record TemperatureReading(double Temperature, DateTime TimeStamp);
}