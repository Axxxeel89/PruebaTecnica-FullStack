using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SisteCredito_API.AutoMapper;
using SisteCredito_Core.Models;
using SisteCredito_Core.Token;
using SisteCredito_Infrastructure.Data;
using SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;
using SisteCredito_Infrastructure.Data.Repository.RepositorioEmpleado;
using SisteCredito_Infrastructure.Data.Repository.RepositorioEstado;
using SisteCredito_Infrastructure.Data.Repository.RepositorioGeneros;
using SisteCredito_Infrastructure.Data.Repository.RepositorioLideres;
using SisteCredito_Infrastructure.Data.Repository.RepositorioUsuarios;
using SisteCredito_Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Los usuarios deben estar autenticados para probar las acciones del controller
builder.Services.AddControllers(options => {
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

//Repositorios 
builder.Services.AddScoped<IRepositoryAreas, RepositoryAreas>();
builder.Services.AddScoped<IRepositoryEmpleados, RepositoryEmpleados>();
builder.Services.AddScoped<IRepositoryLideres, RepositoryLideres>();
builder.Services.AddScoped<IRepositoryReporteHorasExtra, RepositoryReporteHorasExtra>();
builder.Services.AddScoped<IRepositoryUsuarios, RepositoryUsuarios>();
builder.Services.AddScoped<IRepositoryGeneros, RepositoryGeneros>();
builder.Services.AddScoped<IRepositoryEstado, RepositoryEstado>();

//--> Configuracion de los Jwt
var builderSecurity = builder.Services.AddIdentityCore<Usuarios>();
var identityBuilder = new IdentityBuilder(builderSecurity.UserType, builder.Services);

//Contenedor de Mapper
builder.Services.AddAutoMapper(typeof(MappingConfig));

//--> Agregamos el esquema que se va a encargar de agregar las tablas a la migracion
identityBuilder.AddEntityFrameworkStores<ApplicationDbContext>();
identityBuilder.AddSignInManager<SignInManager<Usuarios>>();

//--> Va agregar una referencia para saber la hora en la que se esta creando estos usuarios.
builder.Services.AddSingleton<ISystemClock, SystemClock>();

//--> Debemos inyectar al generador de tokens
builder.Services.AddScoped<IJwtGenerador, JwtGenerador>();

//-> Inyectamos al usuario sesion
builder.Services.AddScoped<IUsuarioSesion, UsuarioSesion>();

builder.Services.AddHttpContextAccessor();

//Seteamos el esquema de seguridad para que un usuario acceda con el token para cada request que envie un cliente.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer( options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidateAudience = false,  //-> Esto significa que cualquier cliente puede enviarme request
                        ValidateIssuer = false //--> Tambien puedo enviarle los resultados a cualquier cliente.
                    };
                });

//--> Agregamos los cors, esto sirve para que el cliente pueda aceptar los verbos Http, get, post, delete
builder.Services.AddCors( o => o.AddPolicy("corsapp", builder => {
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    //--> Acepte request desde cualquier Ip desde widthOrigins
    //-> Acepte AllowAnyMethod, dice que esta permitidos todos los metodos, cualquier cliente puede enviar un metodo Get, put, etc.
    //->Permita cualquier tipo de Header(AllowAnyHeader), dentro del header pue de enviar los tokens de seguridad.
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ManagerMiddleware>();

app.UseAuthentication();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

// using(var ambiente = app.Services.CreateScope())
// {
//     var services = ambiente.ServiceProvider;

//     try{
//         var userManager = services.GetRequiredService<UserManager<Usuarios>>();
//         var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//         var context = services.GetRequiredService<ApplicationDbContext>();
//         await context.Database.MigrateAsync();  //-->Dispara el evento para la creacion de las tablas en la DB
//         await LoadDataBase.InsertarData(context, userManager);
//         // await LoadDataBase.CrearRoles(roleManager);
//         // await LoadDataBase.InsertarData(context, userManager);
//         // await LoadDataBase.AsignarRoles(userManager);

//     }catch(Exception ex){
//         var logging =  services.GetRequiredService<ILogger<Program>>();
//         logging.LogError(ex, "Ocurrio un error en la migracion");
//     }
// }

app.Run();
