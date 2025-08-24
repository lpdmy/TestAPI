var builder = WebApplication.CreateBuilder(args);

// Load configuration t? nhi?u ngu?n (Azure App Service s? inject vào Environment Variables)
builder.Configuration
    .AddEnvironmentVariables(); // Ð?c config t? env (Azure App Settings)
// Add services to the container.

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
