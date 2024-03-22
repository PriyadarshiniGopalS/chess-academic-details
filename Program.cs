using ChessAPIs.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ChessContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChessContext")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("SpecificOrigins",
        builder =>
        {
            builder
            .WithOrigins("https://priyadarshinigopals.github.io", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("SpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.Run();