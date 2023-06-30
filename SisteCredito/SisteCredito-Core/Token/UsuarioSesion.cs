using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SisteCredito_Core.Token;

public class UsuarioSesion : IUsuarioSesion
{
    private readonly IHttpContextAccessor _httpContextAssesor;

    public UsuarioSesion(IHttpContextAccessor httpContextAssesor)
    {
        _httpContextAssesor = httpContextAssesor;
    }
    
    public string ObtenerUsuarioSesion()
    {
        //-> En el contexto del request ya tenemos los datos del usuario
        var userName = _httpContextAssesor.HttpContext!.User?.Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value; //--> El NameIdentifier es el valor que esta almacenando el UserName

        //-->Con esto ya tenemos el UserName
        return userName!;
    }
}