using System;

namespace Domain.Sensors.Shared
{
    public class SensorId
    {
        public string Value { get; }
        
        public SensorId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id can't be empty or null");
            }
            
            Value = id.Trim();
        }
    }
}