using System.Globalization;

namespace IOT_Application.Model
{
    public class DeviceMaster
    {
       public string DeviceId { get; set; }

        public string DeviceName { get; set; }

        public string DeviceType { get; set; }

        public string Status { get; set; }

        public string Ownership { get; set; }

        public string ValidFrom { get; set; }

        public string ValidTo { get; set; }

        public string Market { get; set; }
    }
}
