using System.Collections.Generic;
using System.Linq;
using Domain.Sensors.Shared;
using Microsoft.AspNetCore.Mvc;
using ScaffoldApi.Models;
using Services.Sensors.Temperature;

namespace ScaffoldApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : Controller
    {
        private readonly ITemperatureService _temperatureService;

        public TemperatureController(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }
        
        // GET
        [HttpGet]
        public IEnumerable<TemperatureReadingViewModel> Get(string sensorId)
        {
            var lastReadings = _temperatureService
                .GetAllReadingsFromSensor(new SensorId(sensorId))
                .Take(5)
                // map to the desired entity.
                .Select(x => new TemperatureReadingViewModel(sensorId, x.Temperature, x.TimeStamp))
                .ToList();

            return lastReadings;
        }

        /// <summary>
        /// It's not 100% REST, but for a test I guess it's ok. ;)
        /// </summary>
        /// <param name="sensorId"></param>
        /// <returns></returns>
        [HttpGet("last-reading")]
        public TemperatureReadingViewModel GetLastReading(string sensorId)
        {
            var reading = _temperatureService.GetLastReadingFromSensor(new SensorId(sensorId));
            return new TemperatureReadingViewModel(sensorId, reading.Temperature, reading.TimeStamp);
        }
    }
}