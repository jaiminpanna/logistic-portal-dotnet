using Dapper;
using IOT_Application.Model;
using System.Data;

namespace IOT_Application.Repository.GPSDeviceRepo
{
    public class GPSDeviceRepository : IGPSDeviceRepository
    {

        private readonly IDbConnection _connection;

        public GPSDeviceRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public GPSDevice AddGPSDevice(GPSDevice device)
        {
            var sql = "INSERT INTO GPSDevice (DeviceId, EquipmentType, AccountId, AccountName, CourierId, ContactEmail, Description, Status) Values (@DeviceId, @EquipmentType, @AccountId, @AccountName, @CourierId, @ContactEmail, @Description, @Status)";
            return _connection.QuerySingleOrDefault(sql, device);
        }

        public IEnumerable<GPSDevice> GetGPSDeviceList()
        {
            var sql = "SELECT * FROM GPSDevice";
            return _connection.Query<GPSDevice>(sql);
        }

        public GPSDevice GetGPSDevice(string deviceId)
        {
            var sql = "SELECT * FROM GPSDevice WHERE DeviceId = @DeviceId";
            return _connection.QuerySingleOrDefault<GPSDevice>(sql, new { DeviceId = deviceId });
        }

        public void RemoveGPSDevice(string deviceId)
        {
            var sql = "DELETE FROM GPSDevice WHERE DeviceId = @DeviceId";
            _connection.Execute(sql, new { DeviceId = deviceId });

        }

        public GPSDevice UpdateDevice(GPSDevice device)
        {
            var sql = "UPDATE GPSDevice SET DeviceId=@DeviceId, EquipmentType=@EquipmentType, AccountId=@AccountId, AccountName=@AccountName, CourierId=@CourierId, ContactEmail=@ContactEmail, Description=@Description, Status=@Status WHERE DeviceId=@DeviceId";
            return _connection.QuerySingleOrDefault(sql, device);
        }

        public IEnumerable<GPSDevice> SearchDevice(string searchTerm)
        {
            string sql = @"SELECT * FROM GPSDevice WHERE DeviceId LIKE '%' + @searchTerm + '%'";
            List<GPSDevice> results = _connection.Query<GPSDevice>(sql, new { searchTerm }).ToList();

            return results;

        }
    }
}
