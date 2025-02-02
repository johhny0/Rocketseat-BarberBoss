using Communication.Request;
using Communication.Response;
using Domain.Exceptions;
using Domain.Repositories.Users;
using Domain.Security.Cryptography;
using Domain.Security.Tokens;

namespace Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
        (
        IUsersReadOnlyRepository repository,
        IPasswordEncripter passwordEncripter,
        IAccessTokenGenerator accessTokenGenerator
        ) : IDoLoginUseCase
    {
        public ResponseUser Execute(RequestLogin request)
        {
            var user = repository.GetByEmail(request.Email)
                ?? throw new InvalidLoginException();

            var isPasswordMatch = passwordEncripter.Verify(request.Password, user.Password);

            if (!isPasswordMatch)
            {
                throw new InvalidLoginException();
            }

            return new ResponseUser
            {
                Name = user.Name,
                Token = accessTokenGenerator.Generate(user)
            };
        }
    }
}
