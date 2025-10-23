using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.DataContext;
using WebApi_Estudo.Service.FuncionarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// CORS: política para desenvolvimento (frontend em localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200") // origem do seu Angular dev
            .AllowAnyHeader()
            .AllowAnyMethod();
        // .AllowCredentials(); // habilite SOMENTE se precisar enviar cookies/credenciais
        // se habilitar AllowCredentials(), não use AllowAnyOrigin()
    });
});

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI: seu service
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Opcional: manter redirecionamento para HTTPS
app.UseHttpsRedirection();

// Important: UseRouting antes de UseCors / UseAuthentication / UseAuthorization1
app.UseRouting();

// Aplica a política CORS
app.UseCors("FrontendDev");

// Se tiver autenticação, viria aqui:
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
