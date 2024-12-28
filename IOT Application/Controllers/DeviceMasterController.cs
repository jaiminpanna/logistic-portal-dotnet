using IOT_Application.Model;
using IOT_Application.Repository.DeviceMasterRepo;
using IOT_Application.Repository.GPSDeviceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceMasterController : ControllerBase
    {

        private readonly IDeviceMasterRepository _deviceMasterRepository;

        public DeviceMasterController(IDeviceMasterRepository deviceMasterRepository)
        {
            _deviceMasterRepository = deviceMasterRepository;
        }


        [HttpGet]
        [Route("GetDeviceMasterList")]
        public IActionResult GetDeviceMasterList()
        {
            return Ok(_deviceMasterRepository.GetDeviceMasterList());

        }

        [HttpPost]
        [Route("PostDeviceMaster")]
        public IActionResult AddDeviceMaster(DeviceMaster device)
        {
            return Ok(_deviceMasterRepository.AddDeviceMaster(device));
        }

        [HttpGet]
        [Route("GetDeviceMaster/{deviceId}")]
        public IActionResult GetDeviceMaster(string deviceId)
        {
            return Ok(_deviceMasterRepository.GetDeviceMaster(deviceId));
        }

        [HttpGet]
        [Route("{status}")]
        public IActionResult GetDeviceMasterByStatus(string status)
        {
            return Ok(_deviceMasterRepository.GetDeviceMasterByStatus(status));
        }

        [HttpGet]
        [Route("GetDeviceMasterType/{deviceType}")]
        public IActionResult GetDeviceMasterByType(string deviceType)
        {
            return Ok(_deviceMasterRepository.GetDeviceMasterByType(deviceType));
        }

        [HttpDelete]
        [Route("{deviceId}")]
        public IActionResult RemoveDeviceMaster(string deviceId)
        {

            var data = _deviceMasterRepository.GetDeviceMaster(deviceId);

            if (data != null)
            {
                _deviceMasterRepository.RemoveDeviceMaster(deviceId);
                return Ok();
            }

            return BadRequest("Device Master is not found");
        }

        [HttpPut]
        public IActionResult UpdateDeviceMaster(DeviceMaster device)
        {
            var data = _deviceMasterRepository.GetDeviceMaster(device.DeviceId);

            if (data != null)
            {
                return Ok(_deviceMasterRepository.UpdateDeviceMaster(device));
            }

            return BadRequest("Device Master is not found");
        }

        [HttpGet]
        [Route("SearchMaster/{searchTerm}")]
        public IActionResult SerachMaster(string searchTerm)
        {
            return Ok(_deviceMasterRepository.SearchMaster(searchTerm));
        }
    }
}
