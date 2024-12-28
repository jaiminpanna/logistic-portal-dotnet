using Dapper;
using IOT_Application.Model;
using System.Data;

namespace IOT_Application.Repository.DeviceRoutingRepo
{
    public class DeviceRoutingRepository : IDeviceRoutingRepository
    {

        private readonly IDbConnection _connection;

        public DeviceRoutingRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public DeviceRouting AddDeviceRouting(DeviceRouting routing)
        {
            var sql = "INSERT INTO DeviceRouting (Airline, DeviceModel, ValidFrom, ValidTo) Values (@Airline, @DeviceModel, @ValidFrom, @ValidTo)";
            return _connection.QuerySingleOrDefault(sql, routing);
        }

        public DeviceRouting GetDeviceRouting(string airline)
        {
            var sql = "SELECT * FROM DeviceRouting WHERE Airline = @Airline";
            return _connection.QuerySingleOrDefault<DeviceRouting>(sql, new {Airline = airline});
        }

        public IEnumerable<DeviceRouting> GetDeviceRoutingByAirline(string airline)
        {
            var sql = "SELECT * FROM DeviceConfig WHERE Airline = @Airline";
            return _connection.Query<DeviceRouting>(sql, new { Airline = airline });
        }

        public IEnumerable<DeviceRouting> GetDeviceRoutingByModel(string model)
        {
            var sql = "SELECT * FROM DeviceConfig WHERE DeviceModel = @DeviceModel";
            return _connection.Query<DeviceRouting>(sql, new { DeviceModel = model });
        }

        public IEnumerable<DeviceRouting> GetDeviceRoutingList()
        {
            var sql = "SELECT * FROM DeviceRouting";
            return _connection.Query<DeviceRouting>(sql);
        }

        public void RemoveDeviceRouting(string airline)
        {
            var sql = "DELETE FROM DeviceRouting Where Airline = @Airline";
            _connection.Execute(sql, new {Airline = airline});
        }

        public DeviceRouting UpdateDeviceRouting(DeviceRouting routing)
        {
            var sql = "UPDATE DeviceRouting SET Airline=@Airline, DeviceModel=@DeviceModel, ValidFrom=@ValidFrom, ValidTo=@ValidTo WHERE  Airline=@Airline";
            return _connection.QuerySingleOrDefault(sql, routing);
        }

        public IEnumerable<DeviceRouting> SearchRouting(string searchTerm)
        {
            string sql = @"SELECT * FROM DeviceRouting WHERE Airline LIKE '%' + @searchTerm + '%'";
            List<DeviceRouting> results = _connection.Query<DeviceRouting>(sql, new { searchTerm }).ToList();

            return results;
        }
    }
}
