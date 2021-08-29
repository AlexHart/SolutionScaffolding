using System;

namespace ScaffoldApi.Models
{
    /// <summary>
    /// Class used in case we don't want to directly return the Domain object.
    /// It should be in a library too and in this case is just for the sake of it.
    /// </summary>
    /// <param name="sensorId"></param>
    /// <param name="Temperature"></param>
    /// <param name="TimeStamp"></param>
    public record TemperatureReadingViewModel(string sensorId, double Temperature, DateTime TimeStamp);
}