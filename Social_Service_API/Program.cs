using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Services;
using Social_Service_API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(
	options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
	);

builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IAccesoService, AccesoService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<ITipoAhorroService, TipoAhorroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfilAccesoService, PerfilAccesoService>();
builder.Services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteEstructuraService, ClienteEstructuraService>();
builder.Services.AddScoped<ITipoAhorroClienteService, TipoAhorroClienteService>();
builder.Services.AddScoped<IEstructuraAhorroService, EstructuraAhorroService>();

builder.Services.AddCors(options => options.AddPolicy(name: "ApiOrigins",
	policy =>
	{
		policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
	}));

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}*/

app.UseCors("ApiOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
