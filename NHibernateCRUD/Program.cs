using NHibernateCRUD.Middleware;
using NHibernateCRUD.StartUpExtension;
using Serilog;

var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
Log.Information("Application is starting.");
var builder = WebApplication.CreateBuilder(args);


var connStr = builder.Configuration.GetConnectionString("PostgreSqlConnection");

builder.Services.AddNHibernatePosgreSql(connStr);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
