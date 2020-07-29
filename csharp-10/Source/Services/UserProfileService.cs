using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace Codenation.Challenge.Services
{
    public class UserProfileService : IProfileService
    {
        private const string ADMIN_EMAIL = "tegglestone9@blog.com";

        private readonly CodenationContext _dbContext;
        public UserProfileService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Pega as informações através dos dados do token (valido)
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //context: dados que vieram do token

            var request = context.ValidatedRequest as ValidatedTokenRequest;
            if (request != null)
            {
                User user = _dbContext.Users.FirstOrDefault(x => x.Email == request.UserName);
                if (user != null)
                {
                    var claims = GetUserClaims(user);

                    //ClaimTypes: Email e Role
                    //Pega do "context" as Claims que foram listadas pelo "GetUserClaims"
                    context.IssuedClaims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
                }
            }

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        public static Claim[] GetUserClaims(User user)
        {
            var role = "user";

            if (user.Email == ADMIN_EMAIL) role = "admin";

            return new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };
        }

    }
}