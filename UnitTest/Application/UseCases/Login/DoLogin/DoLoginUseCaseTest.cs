using Application.UseCases.Login.DoLogin;
using Domain.Exceptions;
using FluentAssertions;
using TestUtilities.Communication;
using TestUtilities.Cryptography;
using TestUtilities.Entitties;
using TestUtilities.Repositories;
using TestUtilities.Token;

namespace UnitTest.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCaseTest
    {
        private readonly IDoLoginUseCase _useCase;
        private readonly UsersReadOnlyRepositoryBuilder _repository = new();
        private readonly PasswordEncripterBuilder _passwordEncripter = new();

        public DoLoginUseCaseTest()
        {
            var accessTokenGenerator = new AccessTokenGeneratorBuilder().Build();

            _useCase = new DoLoginUseCase(
                _repository.Build(),
                _passwordEncripter.Build(),
                accessTokenGenerator
                );
        }


        [Fact]
        public void Execute_ShouldDoLogin_WhenInformationIsCorrect()
        {
            // Arrange
            var user = UserBuilder.Build();
            var requestLogin = RequestLoginBuilder.Build();
            requestLogin.Email = user.Email;

            _passwordEncripter.Verify(requestLogin.Password);
            _repository.GetByEmail(user);

            // Act
            var result = _useCase.Execute(requestLogin);

            // Assert
            result.Should().NotBeNull();
            result.Token.Should().NotBeNullOrWhiteSpace();
            result.Name.Should().Be(user.Name);
        }

        [Fact]
        public void Execute_ShouldNotDoLogin_WhenUserNotFound()
        {
            // Arrange
            var user = UserBuilder.Build();
            var requestLogin = RequestLoginBuilder.Build();

            // Act
            var act = () => _useCase.Execute(requestLogin);

            // Assert
            var result = act.Should().Throw<InvalidLoginException>();
            result.Where(e => e.ErrorsMessage.Contains(ExceptionResource.EMAIL_OR_PASSWORD_INVALID));
        }

        [Fact]
        public void Execute_ShouldNotDoLogin_WhenPasswordDontMatch()
        {
            // Arrange
            var user = UserBuilder.Build();
            var requestLogin = RequestLoginBuilder.Build();
            requestLogin.Email = user.Email;

            _repository.GetByEmail(user);

            // Act
            var act = () => _useCase.Execute(requestLogin);

            // Assert
            var result = act.Should().Throw<InvalidLoginException>();
            result.Where(e => e.ErrorsMessage.Contains(ExceptionResource.EMAIL_OR_PASSWORD_INVALID));
        }

    }
}
