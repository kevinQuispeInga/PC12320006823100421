using Microsoft.EntityFrameworkCore;
using PC12320006823100421.CORE.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);
var cnx = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<TallerMecanicoDbContext>(options =>
    options.UseSqlServer(cnx));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
