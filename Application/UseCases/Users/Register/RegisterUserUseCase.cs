using Application.UseCases.Users.Resources;
using AutoMapper;
using Communication.Request;
using Communication.Response;
using Domain;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Repositories.Users;
using Domain.Security.Cryptography;
using FluentValidation.Results;

namespace Application.UseCases.Users.Register
{
    public class RegisterUserUseCase(
        IMapper mapper, 
        IPasswordEncripter encripter,
        IUsersReadOnlyRepository readOnlyRepository,
        IUsersWriteOnlyRepository writeOnlyRepository,
        IUnitOfWork unitOfWork
        ) : IRegisterUserUseCase
    {
        public ResponseUser Execute(RequestUser requestUser)
        {
            Validate(requestUser);

            var user = mapper.Map<User>(requestUser);
            user.Password = encripter.Encrypt(requestUser.Password);

            writeOnlyRepository.Add(user);
            unitOfWork.Commit();

            return new ResponseUser { Name = user.Name, Token = "TOKEN" };
        }

        private void Validate(RequestUser requestUser)
        {
            var validator = new UserValidator();

            var validationResult = validator.Validate(requestUser);

            var emailExists = readOnlyRepository.ExistUserWithEmail(requestUser.Email);
            if (emailExists) 
            {
                var failure = new ValidationFailure(string.Empty, UserValidationResource.EMAIL_ALREADY_REGISTERED);

                validationResult.Errors.Add(failure);
            }

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ValidationException(errorMessages);
            }
        }
    }
}
