using Application.UseCases.Users;
using Application.UseCases.Users.Resources;
using FluentAssertions;
using TestUtilities.Builder;

namespace UnitTest.Application.UseCases.Users
{
    public class UserValidatorTest
    {
        [Fact]
        public void Validate_ShouldBeTrue_WhenUserIsValid()
        {
            // Arrange
            var validator = new UserValidator();
            var request = UserRegisterBuilder.Build();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Validate_ShouldBeFalse_WhenUserNameIsEmpty(string name)
        {
            // Arrange
            var validator = new UserValidator();
            var request = UserRegisterBuilder.Build();
            request.Name = name;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(UserValidationResource.NAME_REQUIRED));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Validate_ShouldBeFalse_WhenUserEmailIsEmpty(string email)
        {
            // Arrange
            var validator = new UserValidator();
            var request = UserRegisterBuilder.Build();
            request.Email = email;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(UserValidationResource.EMAIL_REQUIRED));
        }


        [Fact]
        public void Validate_ShouldBeFalse_WhenUserEmailIsInvalid()
        {
            // Arrange
            var validator = new UserValidator();
            var request = UserRegisterBuilder.Build();
            request.Email = "http://www.google.com";

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(UserValidationResource.EMAIL_INVALID));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Validate_ShouldBeFalse_WhenUserPasswordIsEmpty(string password)
        {
            // Arrange
            var validator = new UserValidator();
            var request = UserRegisterBuilder.Build();
            request.Password = password;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(UserValidationResource.PASSWORD_REQUIRED));
        }


    }
}
