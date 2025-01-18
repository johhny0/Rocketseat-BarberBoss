using Application.UseCases.Users.Resources;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Application.UseCases.Users
{
    public partial class PasswordValidatior<T> : PropertyValidator<T, string>
    {
        public override string Name => "PasswordValidator";
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, UserValidationResource.PASSWORD_REQUIRED);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, UserValidationResource.PASSWORD_TOO_SHORT);
                return false;
            }

            if (!UpperCaseRegex().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, UserValidationResource.PASSWORD_UPPERCASE_REQUIRED);
                return false;
            }

            if (!LowerCaseRegex().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, UserValidationResource.PASSWORD_LOWERCASE_REQUIRED);
                return false;
            }

            if (!DigitRegex().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, UserValidationResource.PASSWORD_DIGIT_REQUIRED);
                return false;
            }

            if (!SpecialCharacterRegex().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, UserValidationResource.PASSWORD_SPECIAL_CHARACTER_REQUIRED);
                return false;
            }

            return true;
        }

        [GeneratedRegex("[A-Z]+")]
        private static partial Regex UpperCaseRegex();
        [GeneratedRegex("[a-z]+")]
        private static partial Regex LowerCaseRegex();
        [GeneratedRegex("[0-9]+")]
        private static partial Regex DigitRegex();
        [GeneratedRegex("[^a-zA-Z0-9]+")]
        private static partial Regex SpecialCharacterRegex();
    }
}
