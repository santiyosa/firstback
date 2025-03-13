using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BackendProject.Data;
using firstback.roles;
using firstback.categorias;
using firstback.user;
using firstback.bootcamps;
using firstback.tematicas;
using firstback.Instituciones;
using firstback.InstitucionesBootcamps;
using firstback.BootcampsTematicas;
using firstback.Oportunidades;
using firstback.UsersOpportunities;
using firstback.InstitutionsOpportunity;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar DbContext con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
);

// Registrar servicios
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IRolesService, RolesService>(); 
builder.Services.AddScoped<ITematicaService, TematicaService>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<IInstitucionService, InstitucionService>();
builder.Services.AddScoped<IBootcampService, BootcampService>();
builder.Services.AddScoped<IInstitucionBootcampService, InstitucionBootcampService>();
builder.Services.AddScoped<IBootcampTematicaService, BootcampTematicaService>();
builder.Services.AddScoped<IOportunidadService, OportunidadService>();
builder.Services.AddScoped<IUsersOpportunitiesServices, UsersOpportunitiesServices>();
builder.Services.AddScoped<IInstitucionService, InstitucionService>();
builder.Services.AddScoped<IInstitutionsOpportunityService, InstitutionsOpportunityService>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(TematicaProfile));

// Configurar controladores y autorización
builder.Services.AddControllers();
builder.Services.AddAuthorization();


// Configurar Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BackendProject Nodo EAFIT",
        Version = "v1",
        Description = "Gestión del backend con estructura modular"
    });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendProject API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();