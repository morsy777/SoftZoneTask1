
using SoftZoneTask1;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
