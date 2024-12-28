using IOT_Application.Model;

namespace IOT_Application.Repository.DeviceRoutingRepo
{
    public interface IDeviceRoutingRepository
    {

        public IEnumerable<DeviceRouting> GetDeviceRoutingList();

        public IEnumerable<DeviceRouting> GetDeviceRoutingByAirline(string airline);

        public IEnumerable<DeviceRouting> GetDeviceRoutingByModel(string model);

        public DeviceRouting AddDeviceRouting(DeviceRouting routing);

        public DeviceRouting GetDeviceRouting(string airline);

        public void RemoveDeviceRouting(string airline);

        public DeviceRouting UpdateDeviceRouting(DeviceRouting routing);

        public IEnumerable<DeviceRouting> SearchRouting(string searchTerm);
    }
}
