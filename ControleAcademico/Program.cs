using ControleAcademico1.Data;
using ControleAcademico1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore; // Adicione o namespace correto para o EF Core
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Configura��o da conex�o com o banco de dados usando Entity Framework Core
builder.Services.AddDbContext<ControleAcademico1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Corre��o na chamada do m�todo

// Registro do servi�o IAutorService e sua implementa��o AutorService
builder.Services.AddScoped<IAutorService, AutorService>();

// Adiciona os controladores com as visualiza��es
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��es do pipeline de requisi��o HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
