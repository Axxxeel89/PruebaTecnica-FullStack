using SisteCredito_Core.Models;

namespace SisteCredito_Core.Token;

public interface IJwtGenerador
{
    
    string CrearToken(Usuarios usuarios);

}