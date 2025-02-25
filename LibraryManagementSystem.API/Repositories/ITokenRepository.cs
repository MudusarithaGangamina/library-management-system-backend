using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
