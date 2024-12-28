using IOT_Application;
using IOT_Application.Repository.DeviceConfigRepo;
using IOT_Application.Repository.DeviceMasterRepo;
using IOT_Application.Repository.DeviceRoutingRepo;
using IOT_Application.Repository.GPSDeviceRepo;
using IOT_Application.Repository.RegisterRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IGPSDeviceRepository, GPSDeviceRepository>();
builder.Services.AddTransient<IDeviceConfigRepository, DeviceConfigRepository>();
builder.Services.AddTransient<IDeviceRoutingRepository, DeviceRoutingRepository>();
builder.Services.AddTransient<IDeviceMasterRepository, DeviceMasterRepository>();
builder.Services.AddTransient<IRegisterUserRepository, RegisterUserRepository>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddControllers()

.AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnection>(new SqlConnection(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
