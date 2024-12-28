using Dapper;
using IOT_Application.Model;
using System.Data;

namespace IOT_Application.Repository.DeviceConfigRepo
{
    public class DeviceConfigRepository : IDeviceConfigRepository
    {

        private readonly IDbConnection _connection;

        public DeviceConfigRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public DeviceConfig AddDeviceConfig(DeviceConfig device)
        {
            var sql = "INSERT INTO DeviceConfig (ConfigurationName, DeviceType, ValidFrom, ValidTo, TemperatureProb, BatteryStatus, BatteryMinRange, BatteryMaxRange, HumidityStatus, HumidityMinRange, HumidityMaxRange, LightStatus, LightMinRange, LightMaxRange, ShockStatus, ShockRange, ShockDuration, TiltStatus, TiltMinRange, TiltMaxRange, PressureStatus, PressureMinRange, PressureMaxRange, TemperatureStatus, TemperatureMinRange, TemperatureMaxRange) " +
                                        "Values (@ConfigurationName, @DeviceType, @ValidFrom, @ValidTo, @TemperatureProb, @BatteryStatus, @BatteryMinRange, @BatteryMaxRange, @HumidityStatus, @HumidityMinRange, @HumidityMaxRange, @LightStatus, @LightMinRange, @LightMaxRange, @ShockStatus, @ShockRange, @ShockDuration, @TiltStatus, @TiltMinRange, @TiltMaxRange, @PressureStatus, @PressureMinRange, @PressureMaxRange, @TemperatureStatus, @TemperatureMinRange, @TemperatureMaxRange)";
            return _connection.QuerySingleOrDefault(sql, device);
        }

        public DeviceConfig GetDeviceConfig(string configName)
        {
            var sql = "SELECT * FROM DeviceConfig WHERE ConfigurationName = @ConfigurationName";
            return _connection.QuerySingleOrDefault<DeviceConfig>(sql, new { ConfigurationName = configName });
        }

        public IEnumerable<DeviceConfig> GetDeviceConfigList()
        {
            var sql = "SELECT * FROM DeviceConfig";
            return _connection.Query<DeviceConfig>(sql);
        }

        public IEnumerable<DeviceConfig> GetDeviceConfigListByDeviceType(string deviceType)
        {
            var sql = "SELECT * FROM DeviceConfig WHERE DeviceType = @DeviceType";
            return _connection.Query<DeviceConfig>(sql, new { DeviceType = deviceType });
        }

        public void RemoveDeviceConfig(string configName)
        {
            var sql = "DELETE FROM DeviceConfig WHERE ConfigurationName = @ConfigurationName";
            _connection.Execute(sql, new { ConfigurationName = configName });
        }

        public DeviceConfig UpdateDeviceConfig(DeviceConfig device)
        {
            var sql = "UPDATE DeviceConfig SET ConfigurationName =@ConfigurationName, DeviceType=@DeviceType, ValidFrom=@ValidFrom, ValidTo=@ValidTo, TemperatureProb=@TemperatureProb, BatteryStatus=@BatteryStatus, BatteryMinRange=@BatteryMinRange, BatteryMaxRange=@BatteryMaxRange, HumidityStatus=@HumidityStatus, HumidityMinRange=@HumidityMinRange, HumidityMaxRange=@HumidityMaxRange, LightStatus=@LightStatus, LightMinRange=@LightMinRange, LightMaxRange=@LightMaxRange, ShockStatus=@ShockStatus, ShockRange=@ShockRange, ShockDuration=@ShockDuration, TiltStatus=@TiltStatus, TiltMinRange=@TiltMinRange, TiltMaxRange=@TiltMaxRange, PressureStatus=@PressureStatus, PressureMinRange=@PressureMinRange, PressureMaxRange=@PressureMaxRange, TemperatureStatus=@TemperatureStatus, TemperatureMinRange=@TemperatureMinRange, TemperatureMaxRange=@TemperatureMaxRange WHERE ConfigurationName=@ConfigurationName";
            return _connection.QuerySingleOrDefault(sql, device);
        }

        public IEnumerable<DeviceConfig> SearchConfig(string searchTerm)
        {
            string sql = @"SELECT * FROM DeviceConfig WHERE ConfigurationName LIKE '%' + @searchTerm + '%'";
            List<DeviceConfig> results = _connection.Query<DeviceConfig>(sql, new { searchTerm }).ToList();

            return results;
        }
    }
}
