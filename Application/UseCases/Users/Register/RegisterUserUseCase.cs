using AutoMapper;
using Communication.Request;
using Communication.Response;
using Domain;
using Domain.Exceptions;

namespace Application.UseCases.Users.Register
{
    public class RegisterUserUseCase(IMapper mapper) : IRegisterUserUseCase
    {
        public ResponseUser Execute(RequestUser requestUser)
        {
            Validate(requestUser);

            var user = mapper.Map<User>(requestUser);

            // Save user to database

            return new ResponseUser { Name = user.Name, Token = "TOKEN" };
        }

        private static void Validate(RequestUser requestUser)
        {
            var validator = new UserValidator();

            var validationResult = validator.Validate(requestUser);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ValidationException(errorMessages);
            }
        }
    }
}
