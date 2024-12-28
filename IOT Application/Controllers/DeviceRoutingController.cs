using IOT_Application.Model;
using IOT_Application.Repository.DeviceRoutingRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceRoutingController : ControllerBase
    {

        private readonly IDeviceRoutingRepository _repository;

        public DeviceRoutingController(IDeviceRoutingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetDeviceRoutingList")]
        public IActionResult GetDeviceRoutingList()
        {
            return Ok(_repository.GetDeviceRoutingList());

        }

        [HttpGet]
        [Route("GetDeviceRouting/{airline}")]
        public IActionResult GetDeviceRouting(string airline)
        {
            return Ok(_repository.GetDeviceRouting(airline));   
        }

        [HttpPost]
        [Route("PostDeviceRouting")]
        public IActionResult AddDeviceRouting(DeviceRouting routing)
        {
            return Ok(_repository.AddDeviceRouting(routing));
        }

        [HttpGet]
        [Route("{airline}")]
        public IActionResult GetDeviceRoutingByAirline(string airline)
        {
            return Ok(_repository.GetDeviceRoutingByAirline(airline));
        }

        [HttpGet]
        [Route("{model}")]
        public IActionResult GetDeviceRoutingByModel(string model)
        {
            return Ok(_repository.GetDeviceRoutingByModel(model));
        }

        [HttpDelete]
        [Route("{airline}")]
        public IActionResult RemoveDeviceRouting(string airline)
        {

            var data = _repository.GetDeviceRouting(airline);

            if (data != null)
            {
                _repository.RemoveDeviceRouting(airline);
                return Ok();
            }

            return BadRequest("Device Routing is not found");
        }

        [HttpPut]
        public IActionResult UpdateDeviceRouting(DeviceRouting device)
        {
            var data = _repository.GetDeviceRouting(device.Airline);

            if (data != null)
            {
                return Ok(_repository.UpdateDeviceRouting(device));
            }

            return BadRequest("Device Routing is not found");
        }

        [HttpGet]
        [Route("SearchRouting/{searchTerm}")]
        public IActionResult SerachRouting(string searchTerm)
        {
            return Ok(_repository.SearchRouting(searchTerm));
        }

    }
}
