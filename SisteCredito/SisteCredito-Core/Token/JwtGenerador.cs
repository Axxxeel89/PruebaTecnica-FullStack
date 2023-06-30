using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SisteCredito_Core.Models;

namespace SisteCredito_Core.Token;

public class JwtGenerador : IJwtGenerador
{
    public IConfiguration _configuration; 

    public JwtGenerador(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CrearToken(Usuarios usuarios)
    {
        var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.NameId, usuarios.UserName!),
            new Claim("userId", usuarios.Id),
            new Claim("email", usuarios.Email!)
        };

        //-> Configuracion de la Key y la firma del token
        var Jwt = _configuration.GetSection("Jwt").Get<Jwt>();  //--> Jalamos la data de settings
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt!.Key));
        var credenctials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

         //--> Desarrollo de PayLoad
        var tokenDescription = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddHours(8),
            SigningCredentials = credenctials 
        };

        //--> Enviaremos el token firmado y con los datos
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
        
    }
}