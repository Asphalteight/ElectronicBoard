using AutoMapper;
using Board.Infrastructure.MapProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add automapper
builder.Services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static MapperConfiguration GetMapperConfiguration()
{
    var configuration = new MapperConfiguration(cfg => 
    {
        cfg.AddProfile<AdvertisementProfile>();
        cfg.AddProfile<AccountProfile>();
    });
    configuration.AssertConfigurationIsValid();
    return configuration;
}