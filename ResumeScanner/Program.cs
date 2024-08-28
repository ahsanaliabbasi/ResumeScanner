using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ResumeScanner.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string appconnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ResumeScannerDBContext>(options => options.UseSqlServer(appconnectionString));

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.Logger.Log(LogLevel.Debug, "Debug Message");
app.Logger.Log(LogLevel.Warning, "Warning Message");
app.Logger.Log(LogLevel.Critical, "Critical Message");


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
