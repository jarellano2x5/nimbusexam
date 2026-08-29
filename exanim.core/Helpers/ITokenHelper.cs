using System.Security.Claims;

namespace exanim.core.Helpers;

public interface ITokenHelper
{
    string Generar(string usuario, string identificador, IEnumerable<string>? prfs = null);
    ClaimsPrincipal? Validado(string token);
}