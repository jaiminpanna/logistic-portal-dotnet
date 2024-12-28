using Dapper;
using IOT_Application.Model;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IOT_Application.Repository.RegisterRepo
{
    public class RegisterUserRepository : IRegisterUserRepository
    {

        private readonly IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public RegisterUserRepository(IDbConnection connection, IConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;

        }
        public string CheckUser(LoginUser user)
        {
            var sql = "SELECT * FROM UserData WHERE UserName=@userName COLLATE SQL_Latin1_General_CP1_CS_AS AND Password=@password COLLATE SQL_Latin1_General_CP1_CS_AS";

            var data = _connection.QuerySingleOrDefault(sql, new { userName = user.UserName, password = user.Password });

            if (data != null)

                return "True";
            else
                return "False";
        }

        public RegisterUser GetUser(string userName)
        {
            var sql = "SELECT * FROM UserData WHERE UserName = @userName";
            return _connection.QuerySingleOrDefault<RegisterUser>(sql, new { UserName = userName });
        }

        public string GetToken(LoginUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UserName", user.UserName),
                new Claim("Password", user.Password )

            };

            var token = new JwtSecurityToken(_configuration["Jwt:Isssuer"], _configuration["Jwt:Audience"],
                         claims,
                         expires: DateTime.Now.AddMinutes(1),
                         signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RegisterUser AddUser(RegisterUser user)
        {
            var sql = "INSERT INTO UserData (Name, Email, UserName, Password, ConfirmPassword) Values (@Name, @Email, @UserName, @Password, @ConfirmPassword)";
            return _connection.QuerySingleOrDefault(sql, user);
        }
    }
}
