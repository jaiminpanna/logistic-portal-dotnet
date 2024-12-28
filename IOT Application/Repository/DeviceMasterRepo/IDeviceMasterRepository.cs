using IOT_Application.Model;

namespace IOT_Application.Repository.DeviceMasterRepo
{
    public interface IDeviceMasterRepository
    {

        public IEnumerable<DeviceMaster> GetDeviceMasterList();

        public IEnumerable<DeviceMaster> GetDeviceMasterByStatus(string status);

        public IEnumerable<DeviceMaster> GetDeviceMasterByType(string deviceType);

        public DeviceMaster AddDeviceMaster(DeviceMaster device);

        public DeviceMaster GetDeviceMaster(string deviceId);

        public void RemoveDeviceMaster(string deviceId);

        public DeviceMaster UpdateDeviceMaster (DeviceMaster device);

        public IEnumerable<DeviceMaster> SearchMaster(string searchTerm);
    }
}
