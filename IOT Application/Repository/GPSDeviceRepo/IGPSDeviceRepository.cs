using IOT_Application.Model;

namespace IOT_Application.Repository.GPSDeviceRepo
{
    public interface IGPSDeviceRepository
    {

        public IEnumerable<GPSDevice> GetGPSDeviceList();

        public GPSDevice AddGPSDevice(GPSDevice device);

        public GPSDevice GetGPSDevice(string deviceId);

        public void RemoveGPSDevice(string deviceId);

        public GPSDevice UpdateDevice(GPSDevice device);

        public IEnumerable<GPSDevice> SearchDevice(string searchTerm);

    }
}
