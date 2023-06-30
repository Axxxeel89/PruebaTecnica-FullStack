using System.Net;

namespace SisteCredito_Infrastructure.Middlewares;

public class MiddlewareException : Exception
{
    public HttpStatusCode Codigo;

    public object? Errores {get; set;}

    public MiddlewareException(HttpStatusCode codigo, object? errores)
    {
        Codigo = codigo;
        Errores = errores;
    }
}