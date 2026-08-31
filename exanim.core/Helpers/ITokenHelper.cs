using System.Security.Claims;

namespace exanim.core.Helpers;

public interface ITokenHelper
{
    string Generar(string identificador, string tenant, IEnumerable<string>? prfs = null);
    ClaimsPrincipal? Validado(string token);
}