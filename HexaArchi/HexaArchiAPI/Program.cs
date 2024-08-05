using HexaArchi.API.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddBusinessServices();
// Add AutoMapper
builder.Services.AddAutoMapperConfiguration();

builder.Services.AddRabbitMQ(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Configure the JSON serializer to avoid circular references
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

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
