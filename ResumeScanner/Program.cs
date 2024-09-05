using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ResumeScanner.Data;
using ResumeScanner.Mapper;
using ResumeScanner.Models;
using ResumeScanner.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string appconnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Setting up DB Connection
builder.Services.AddDbContext<ResumeScannerDBContext>(options => options.UseSqlServer(appconnectionString));

// Setting up Identity DB
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ResumeScannerDBContext>()
        .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = false;
    //options.Password.RequireLowercase = true;
    //options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    //options.Password.RequiredUniqueChars = 1;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;

    // User settings
    options.User.RequireUniqueEmail = true;
});

// Adding configrations for automapper
builder.Services.AddAutoMapper(typeof(MapperProfile));


// Here we define all the interfaces and their implementation
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
