using System;
using System.Collections.Generic;
using Domain.Sensors.Shared;
using Domain.Sensors.Temperature;
using Repositories.Sensors.Temperature;

namespace Services.Sensors.Temperature
{
    public class TemperatureService : ITemperatureService
    {
        private readonly ITemperatureRepository _repository;

        public TemperatureService(ITemperatureRepository repository)
        {
            _repository = repository;
        }

        public TemperatureReading GetLastReadingFromSensor(SensorId id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            
            return _repository.GetLastReadingFromSensor(id);
        }
        public IEnumerable<TemperatureReading> GetAllReadingsFromSensor(SensorId id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            
            return _repository.GetAllReadingsFromSensor(id);
        }
        
    }
}