using IOT_Application.Model;
using IOT_Application.Repository.GPSDeviceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPSDeviceController : ControllerBase
    {

        private readonly IGPSDeviceRepository _gpsDeviceRepository;

        public GPSDeviceController(IGPSDeviceRepository gPSDeviceRepository)
        {
            _gpsDeviceRepository = gPSDeviceRepository;
        }

        [HttpGet]
        [Route("GetGPSDeviceList")]
        public IActionResult GetGPSDeviceList()
        {
            return Ok(_gpsDeviceRepository.GetGPSDeviceList());

        }

        [HttpPost]
        [Route("PostGPSDevice")]
        public IActionResult AddGPSDevice(GPSDevice device)
        {
            return Ok(_gpsDeviceRepository.AddGPSDevice(device));
        }

        [HttpGet]
        [Route("{deviceId}")]
        public IActionResult GetDevice(string deviceId)
        {
            return Ok(_gpsDeviceRepository.GetGPSDevice(deviceId));
        }

        [HttpDelete]
        [Route("{deviceId}")]
        public IActionResult RemoveDevice(string deviceId)
        {

            var data = _gpsDeviceRepository.GetGPSDevice(deviceId);

            if (data != null)
            {
                _gpsDeviceRepository.RemoveGPSDevice(deviceId);
                return Ok();
            }

            return BadRequest("Device is not found");
        }

        [HttpPut]
        public IActionResult UpdateDevice(GPSDevice device)
        {
            var data = _gpsDeviceRepository.GetGPSDevice(device.DeviceId);

            if (data != null)
            {
                return Ok(_gpsDeviceRepository.UpdateDevice(device));
            }

            return BadRequest("Device is not found");
        }

        [HttpGet]
        [Route("SearchDevice/{searchTerm}")]
        public IActionResult SerachDevice(string searchTerm)
        {
            return Ok(_gpsDeviceRepository.SearchDevice(searchTerm));
        }
    }
}
