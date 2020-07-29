using Codenation.Challenge.Models;
using IdentityModel.Client;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext _dbContext;
        public PasswordValidatorService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Valida o usuario, pra poder gerar o Token
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //UserName = Email, conforme foi definido
            User user = FindUserByEmailAndPassword(email: context.UserName, password: context.Password);

            if (user == null)
            {
                context.Result = new GrantValidationResult(
                    error: TokenRequestErrors.InvalidGrant,
                    errorDescription: "Invalid username or password"
                    );
            }
            else
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),//Subject = Identificação do usuario que esta autenticando
                    authenticationMethod: "custom",
                    claims: UserProfileService.GetUserClaims(user)//Claims= Informações do usuario -> No caso: Email e Role
                    );
            }

            return Task.CompletedTask;
        }

        private User FindUserByEmailAndPassword(string email, string password)
        {
            return _dbContext.Users
                 .Where(u => u.Email == email && u.Password == password)
                 .AsNoTracking()
                 .FirstOrDefault();
        }

    }
}