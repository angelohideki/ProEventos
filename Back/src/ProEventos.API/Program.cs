using IProEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.DTOs.Mappings;
using ProEventos.Application;
using ProEventos.Application.Contratos;
using ProEventos.Persistence;
using ProEventos.Persistence.Contextos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAutoMapper(typeof(ProdutoDTOMappingProfile));       
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IEventoPersist, EventoPersist>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#pragma warning disable CS8600 // Convers�o de literal nula ou poss�vel valor nulo em tipo n�o anul�vel.
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8600 // Convers�o de literal nula ou poss�vel valor nulo em tipo n�o anul�vel.

builder.Services.AddDbContext<ProEventosContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
);

app.MapControllers();

app.Run();
