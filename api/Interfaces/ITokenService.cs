using JobApplicationSystem.api.Models;

namespace JobApplicationSystem.api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
