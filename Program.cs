using Microsoft.Extensions.Options;
using recordXAPI.Configurations;
using recordXAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Bind the DatabaseSettings section from appsettings.json
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

// Register IDatabaseSettings for dependency injection
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

// Register the services that use the database settings
builder.Services.AddSingleton<TransactionService>();
builder.Services.AddSingleton<CustomerService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
