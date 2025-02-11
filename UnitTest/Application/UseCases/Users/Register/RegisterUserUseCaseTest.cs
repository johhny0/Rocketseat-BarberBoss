
using Application.UseCases.Users.Register;
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
        private readonly RegisterUserUseCase _useCase;

        public RegisterUserUseCaseTest()
        {
            var mapper = MapperBuilder.Build();

            var unitOfWork = UnitOfWorkBuilder.Build();

            var userReadyOnly = new UsersReadOnlyRepositoryBuilder().Build();

            var userWriteOnly = UsersWriteOnlyRepositoryBuilder.Build();

            var accessTokenGenerator = AccessTokenGeneratorBuilder.Build();

            var passwordEncrypter = PasswordEncripterBuilder.Build();

            _useCase = new RegisterUserUseCase(
                mapper,
                passwordEncrypter,
                userReadyOnly,
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

    }
}
