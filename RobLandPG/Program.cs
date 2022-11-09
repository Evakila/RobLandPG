using Microsoft.EntityFrameworkCore;
using RobLandPG.Data;
using RobLandPG.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RoblandCMContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddCors(policyBuilder =>
//    policyBuilder.AddDefaultPolicy(policy =>
//        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
//);
builder.Services.AddCors(Options =>
{
    Options.AddPolicy(name: "myAllowSpecificOrigins",
        builder =>
        {
            //builder.WithOrigins("http://localhost:40", "http://localhost:8080/", "http://192.168.1.9:40/")
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("myAllowSpecificOrigins");
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
