using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace IOT_Application.Model
{
    public class DeviceConfig
    {
        public string ConfigurationName { get; set; }

        public string DeviceType { get; set; }
     
        public string ValidFrom { get; set; }
      
        public string ValidTo { get; set; } 

        public string TemperatureProb { get; set; }

        public string BatteryStatus { get; set; }

        public int BatteryMinRange { get; set; }

        public int BatteryMaxRange { get; set; }

        public string HumidityStatus { get; set; }

        public int HumidityMinRange { get; set; }

        public int HumidityMaxRange { get; set; }

        public string LightStatus { get; set; }

        public int LightMinRange { get; set; }

        public int LightMaxRange { get; set; }

        public string ShockStatus { get; set; }

        public int ShockRange { get; set; }

        public int ShockDuration { get; set; }

        public string TiltStatus { get; set; }

        public int TiltMinRange { get; set; }

        public int TiltMaxRange { get; set; }

        public string PressureStatus { get; set; }

        public int PressureMinRange { get; set; }

        public int PressureMaxRange { get; set; }

        public string TemperatureStatus { get; set; }
      
        public int TemperatureMinRange { get; set; }

        public int TemperatureMaxRange { get; set; }




    }
}
