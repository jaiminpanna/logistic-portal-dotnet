using Dapper;
using IOT_Application.Model;
using System.Data;
using System.Reflection;

namespace IOT_Application.Repository.DeviceMasterRepo
{
    public class DeviceMasterRepository: IDeviceMasterRepository
    {

        private readonly IDbConnection _connection;

        public DeviceMasterRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public DeviceMaster AddDeviceMaster(DeviceMaster device)
        {
            var sql = "INSERT INTO DeviceMaster (DeviceId, DeviceName, DeviceType, Status, Ownership, ValidFrom, ValidTo, Market) Values (@DeviceId, @DeviceName, @DeviceType, @Status, @Ownership, @ValidFrom, @ValidTo, @Market)";
            return _connection.QuerySingleOrDefault(sql, device);
        }

        public DeviceMaster GetDeviceMaster(string deviceId)
        {
            var sql = "SELECT * FROM DeviceMaster WHERE DeviceId = @DeviceId";
            return _connection.QuerySingleOrDefault<DeviceMaster>(sql, new { DeviceId = deviceId });
        }

        public IEnumerable<DeviceMaster> GetDeviceMasterByStatus(string status)
        {
            var sql = "SELECT * FROM DeviceMaster WHERE Status = @Status";
            return _connection.Query<DeviceMaster>(sql, new { Status = status });
        }

        public IEnumerable<DeviceMaster> GetDeviceMasterByType(string deviceType)
        {
            var sql = "SELECT * FROM DeviceMaster WHERE DeviceType = @DeviceType";
            return _connection.Query<DeviceMaster>(sql, new { DeviceType = deviceType });
        }

        public IEnumerable<DeviceMaster> GetDeviceMasterList()
        {
            var sql = "SELECT * FROM DeviceMaster";
            return _connection.Query<DeviceMaster>(sql);
        }

        public void RemoveDeviceMaster(string deviceId)
        {
            var sql = "DELETE FROM DeviceMaster Where DeviceId = @DeviceId";
            _connection.Execute(sql, new { DeviceId = deviceId });
        }

        public DeviceMaster UpdateDeviceMaster(DeviceMaster device)
        {
            var sql = "UPDATE DeviceMaster SET DeviceId=@DeviceId, DeviceName=@DeviceName, DeviceType=@DeviceType, Status=@Status, Ownership=@Ownership, ValidFrom=@ValidFrom, ValidTo=@ValidTo, Market=@Market WHERE DeviceId=@DeviceId";
            return _connection.QuerySingleOrDefault(sql, device);
        }

        public IEnumerable<DeviceMaster> SearchMaster(string searchTerm)
        {
            string sql = @"SELECT * FROM DeviceMaster WHERE DeviceId LIKE '%' + @searchTerm + '%'";
            List<DeviceMaster> results = _connection.Query<DeviceMaster>(sql, new { searchTerm }).ToList();

            return results;
        }

    }
}
