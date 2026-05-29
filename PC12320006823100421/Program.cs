using Microsoft.EntityFrameworkCore;
using PC12320006823100421.CORE.Infrastructure.Data;
using PC12320006823100421.CORE.Core.Interfaces;
using PC12320006823100421.CORE.Core.Services;
using PC12320006823100421.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var cnx = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<TallerMecanicoDbContext>(options =>
    options.UseSqlServer(cnx));

builder.Services.AddTransient<IOrdenServicioRepository, OrdenServicioRepository>();
builder.Services.AddTransient<IOrdenServicioService, OrdenServicioService>();

builder.Services.AddControllers();

// OpenAPI / Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();