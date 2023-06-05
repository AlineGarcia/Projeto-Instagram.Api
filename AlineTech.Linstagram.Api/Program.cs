using AlineTech.Linstagram.Api.Configs;
using AlineTech.Linstagram.Api.Infra.Repositories;
using AlineTech.Linstagram.Api.Interfaces.Repositories;
using AlineTech.Linstagram.Api.Interfaces.Services;
using AlineTech.Linstagram.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbConfig(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Development", opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IPerfilService, PerfilService>();
builder.Services.AddTransient<IPublicacaoService, PublicacaoService>();

builder.Services.AddTransient<IPerfilRepository, PerfilRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPublicacaoRepository, PublicacaoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Development");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
