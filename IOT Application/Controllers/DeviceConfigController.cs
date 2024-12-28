using IOT_Application.Model;
using IOT_Application.Repository.DeviceConfigRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceConfigController : ControllerBase
    {

        private readonly IDeviceConfigRepository _deviceConfigRepository;

        public DeviceConfigController(IDeviceConfigRepository deviceConfigRepository)
        {
            _deviceConfigRepository = deviceConfigRepository;
        }


        [HttpGet]
        [Route("GetDeviceConfigList")]
        public IActionResult GetDeviceConfigList()
        {
            return Ok(_deviceConfigRepository.GetDeviceConfigList());

        }

        [HttpGet]
        [Route("GetDevice/{deviceType}")]
        public IActionResult GetDeviceConfigListByDeviceType(string deviceType)
        {
            return Ok(_deviceConfigRepository.GetDeviceConfigListByDeviceType(deviceType));

        }

        [HttpPost]
        [Route("PostDeviceConfig")]
        public IActionResult AddDeviceConfig(DeviceConfig device)
        {
            return Ok(_deviceConfigRepository.AddDeviceConfig(device));
        }

        [HttpGet]
        [Route("{configName}")]
        public IActionResult GetDeviceConfig(string configName)
        {
            return Ok(_deviceConfigRepository.GetDeviceConfig(configName));
        }

        [HttpDelete]
        [Route("{configName}")]
        public IActionResult RemoveDeviceConfig(string configName)
        {
            var data = _deviceConfigRepository.GetDeviceConfig(configName);

            if (data != null)
            {
                _deviceConfigRepository.RemoveDeviceConfig(configName);
                return Ok();
            }

            return BadRequest("Device Configuration is not found");
        }

        [HttpPut]
        public IActionResult UpdateDeviceConfig(DeviceConfig device)
        {
            var data = _deviceConfigRepository.GetDeviceConfig(device.ConfigurationName);

            if (data != null)
            {
                return Ok(_deviceConfigRepository.UpdateDeviceConfig(device));
            }

            return BadRequest("Device Configuration is not found");
        }

        [HttpGet]
        [Route("SearchConfig/{searchTerm}")]
        public IActionResult SerachConfig(string searchTerm)
        {
            return Ok(_deviceConfigRepository.SearchConfig(searchTerm));
        }

    }
}
