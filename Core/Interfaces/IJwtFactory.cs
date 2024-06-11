using System.Security.Claims;

namespace Services.C.Core.Interfaces
{
    public interface IJwtFactory
    {
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
