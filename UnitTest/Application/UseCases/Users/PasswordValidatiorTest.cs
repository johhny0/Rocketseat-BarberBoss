using Application.UseCases.Users;
using Application.UseCases.Users.Resources;
using Communication.Request;
using FluentAssertions;
using FluentValidation;
using TestUtilities.Builder;

namespace UnitTest.Application.UseCases.Users
{
    public class PasswordValidatiorTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Validate_ShouldBeFalse_WhenUserPasswordIsEmpty(string password, string message)
        {
            // Arrange
            var validator = new PasswordValidatior<RequestUser>();
            var userRequest = UserRegisterBuilder.Build();
            var validatorContext = new ValidationContext<RequestUser>(userRequest);

            // Act
            var result = validator.IsValid(validatorContext, password);

            // Assert
            result.Should().BeFalse();
            validatorContext.MessageFormatter.PlaceholderValues["ErrorMessage"].Should().Be(message);
        }

        public static IEnumerable<object[]> TestData =>
        [
            ["a", UserValidationResource.PASSWORD_TOO_SHORT],
            ["aaaaaaa", UserValidationResource.PASSWORD_TOO_SHORT],
            ["aaaaaaaa", UserValidationResource.PASSWORD_UPPERCASE_REQUIRED],
            ["AAAAAAAA", UserValidationResource.PASSWORD_LOWERCASE_REQUIRED],
            ["Aaaaaaaa", UserValidationResource.PASSWORD_DIGIT_REQUIRED],
            ["Aaaaaaa1", UserValidationResource.PASSWORD_SPECIAL_CHARACTER_REQUIRED],
        ];

    }

}
