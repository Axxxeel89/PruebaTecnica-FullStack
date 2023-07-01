using Microsoft.AspNetCore.Identity;
using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data;

public class LoadDataBase
{
   public static async Task CrearRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Gerente"))
        {
            await roleManager.CreateAsync(new IdentityRole("Gerente"));
        }

        if (!await roleManager.RoleExistsAsync("LiderTecnico"))
        {
            await roleManager.CreateAsync(new IdentityRole("LiderTecnico"));
        }

        if (!await roleManager.RoleExistsAsync("Tesoreria"))
        {
            await roleManager.CreateAsync(new IdentityRole("Tesoreria"));
        }
    }

    public static async Task InsertarData(ApplicationDbContext dbContext, UserManager<Usuarios> usuarioManager)
    {
     
        if(!usuarioManager.Users.Any())
        {
            var usuario = new Usuarios{
                Nombres = "John",
                Apellidos = "Rios",
                Rol = "Gerente",
                Email = "john.rios@sisteCredito.com",
                UserName = "Alex.Rios",
            };

            await usuarioManager.CreateAsync(usuario, "Siste2023*");

            var usuario2 = new Usuarios{
                Nombres = "Santiago",
                Apellidos = "Rios",
                Rol = "LiderTecnico",
                Email = "santiago.rios@sisteCredito.com",
                UserName = "Santiago.Rios",
            };

            await usuarioManager.CreateAsync(usuario2, "Siste2023*");

            var usuario3 = new Usuarios{
                Nombres = "Vivian",
                Apellidos = "Ochoa",
                Rol = "Tesoreria",
                Email = "vivian.ochoa@sisteCredito.com",
                UserName = "vivian.ochoa",
            };

            await usuarioManager.CreateAsync(usuario3, "Siste2023*");

            var usuario4 = new Usuarios{
                Nombres = "Paulina",
                Apellidos = "David",
                Rol = "Empleado",
                Email = "paulina.david@sisteCredito.com",
                UserName = "paulina.david",
            };

            await usuarioManager.CreateAsync(usuario4, "Siste2023*");

            await dbContext.SaveChangesAsync();
        }

        
        if(!dbContext.Generos.Any())//--> Si no tiene record entonces vas a generar por defecto el siguiente inmueble
        {
            dbContext.Generos.AddRange(
                new Generos{
                    Nombre = "Masculino",
                },

                new Generos{
                    Nombre = "Femenino",
                },

                new Generos{
                    Nombre = "Otros",
                }    

            );

        }

        if(!dbContext.Areas.Any())//--> Si no tiene record entonces vas a generar por defecto el siguiente inmueble
        {
            dbContext.Areas.AddRange(
                new Areas{
                    Nombre = "Recursos Humanos",
                },

                new Areas{
                    Nombre = "Tecnologia",
                },

                new Areas{
                    Nombre = "Gerencia",
                },

                new Areas{
                    Nombre = "Tesoreria",
                }
            );
                
        }
    }

    public static async Task AsignarRoles(UserManager<Usuarios> userManager)
    {
        var usuario = await userManager.FindByNameAsync("John");
        await userManager.AddToRoleAsync(usuario!, "Gerente");

        var usuario2 = await userManager.FindByNameAsync("Santiago");
        await userManager.AddToRoleAsync(usuario2!, "LiderTecnico");

        var usuario3 = await userManager.FindByNameAsync("Vivian");
        await userManager.AddToRoleAsync(usuario3!, "Tesoreria");

        var usuario4 = await userManager.FindByNameAsync("Paulina");
        await userManager.AddToRoleAsync(usuario4!, "Empleado");

    }

}