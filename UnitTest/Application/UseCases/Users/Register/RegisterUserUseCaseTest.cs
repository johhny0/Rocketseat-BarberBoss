
using Application.UseCases.Users.Register;
using Application.UseCases.Users.Resources;
using Domain.Exceptions;
using FluentAssertions;
using TestUtilities.Builder;
using TestUtilities.Cryptography;
using TestUtilities.Mapper;
using TestUtilities.Repositories;
using TestUtilities.Token;

namespace UnitTest.Application.UseCases.Users.Register
{
    public class RegisterUserUseCaseTest
    {
        private readonly IRegisterUserUseCase _useCase;
        private UsersReadOnlyRepositoryBuilder _usersReadOnlyRepository = new UsersReadOnlyRepositoryBuilder();

        public RegisterUserUseCaseTest()
        {
            var mapper = MapperBuilder.Build();

            var unitOfWork = UnitOfWorkBuilder.Build();

            var userWriteOnly = UsersWriteOnlyRepositoryBuilder.Build();

            var accessTokenGenerator = new AccessTokenGeneratorBuilder().Build();

            var passwordEncrypter = new PasswordEncripterBuilder().Build();

            _useCase = new RegisterUserUseCase(
                mapper,
                passwordEncrypter,
                _usersReadOnlyRepository.Build(),
                userWriteOnly,
                accessTokenGenerator,
                unitOfWork);
        }

        [Fact]
        public void Execute_ShouldSaveUser_WhenItHaveAllInformation()
        {
            // Arrange
            var request = UserRegisterBuilder.Build();

            // Act
            var result = _useCase.Execute(request);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void Execute_ShouldNotSaveUser_WhenItNameIsEmpty()
        {
            // Arrange
            var request = UserRegisterBuilder.Build();
            request.Name = string.Empty;

            // Act
            var act = () => _useCase.Execute(request);

            // Assert
            var result = act.Should().Throw<ValidationException>();
            result
                .Where(ex => ex.ErrorsMessage
                .Contains(UserValidationResource.NAME_REQUIRED));
        }

        [Fact]
        public void Execute_ShouldNotSaveUser_WhenUserAlreadyExists()
        {
            // Arrange
            var request = UserRegisterBuilder.Build();
            _usersReadOnlyRepository.ExistUserWithEmail(request.Email);

            // Act
            var act = () => _useCase.Execute(request);

            // Assert
            var result = act.Should().Throw<ValidationException>();
            result
                .Where(ex => ex.ErrorsMessage
                .Contains(UserValidationResource.EMAIL_ALREADY_REGISTERED));
        }

    }
}
