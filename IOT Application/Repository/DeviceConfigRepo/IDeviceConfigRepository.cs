using IOT_Application.Model;

namespace IOT_Application.Repository.DeviceConfigRepo
{
    public interface IDeviceConfigRepository
    {

        public IEnumerable<DeviceConfig> GetDeviceConfigList();

        public IEnumerable<DeviceConfig> GetDeviceConfigListByDeviceType(string deviceType);

        public DeviceConfig AddDeviceConfig(DeviceConfig device);

        public DeviceConfig GetDeviceConfig(string configName);

        public void RemoveDeviceConfig(string configName);

        public DeviceConfig UpdateDeviceConfig(DeviceConfig device);

        public IEnumerable<DeviceConfig> SearchConfig(string searchTerm);
    }
}
