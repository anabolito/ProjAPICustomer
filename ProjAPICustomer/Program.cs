using Microsoft.Extensions.Options;
using ProjAPICustomer.Config;
using ProjAPICustomer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<ProjCustomerSettings>(builder.Configuration.GetSection("ProjCustomerSettings"));
builder.Services.AddSingleton<IProjCustomerSettings>(s => s.GetRequiredService<IOptions<ProjCustomerSettings>>().Value);

builder.Services.AddSingleton<CityService>();

builder.Services.AddSingleton<AddressService>();

builder.Services.AddSingleton<CustomerService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
