using Domain.Interface.InterfaceGenerics;
using Domain.Interfaces.InterfaceCategoria;
using Domain.Interfaces.InterfaceDespesa;
using Domain.Interfaces.InterfaceSistemaFinanceiro;
using Domain.Interfaces.InterfaceUsuarioSistemaFinanceiro;
using Domain.InterfaceServices;
using Domain.Services;
using Infra.Data;
using Infra.Repositories.RepositoryCategoria;
using Infra.Repositories.RepositoryDespesa;
using Infra.Repositories.RepositoryGeneric;
using Infra.Repositories.RepositorySistemaFinanceiro;
using Infra.Repositories.RepositoryUsuarioSistemaFinanceiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NetDevPack.Identity.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SistemaFinanceiro",
        Version = "v1",
        Description = "Descrição da API",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });

});

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddIdentityEntityFrameworkContextConfiguration(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"),
    b => b.MigrationsAssembly("Infra")));

builder.Services.AddIdentityConfiguration();

builder.Services.AddJwtConfiguration(builder.Configuration, "AppSettings");

// Interface e Repositorio
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddSingleton<ICategoria, RepositoryCategoria>();
builder.Services.AddSingleton<IDespesa, RepositoryDespesa>();
builder.Services.AddSingleton<ISistemaFinanceiro, RepositorySistemaFinanceiro>();
builder.Services.AddSingleton<IUsuarioSistemaFinanceiro, RepositoryUsuarioSistemaFinanceiro>();

// Serviço Dominio
builder.Services.AddSingleton<ICategoriaService, CategoriaService>();
builder.Services.AddSingleton<IDespesaService, DespesaService>();
builder.Services.AddSingleton<ISistemaFinanceiroService, SistemaFinanceiroService>();
builder.Services.AddSingleton<IUsuarioSistemaFinanceiroService, UsuarioSistemaFinanceiroService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthConfiguration();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
