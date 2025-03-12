using Bogus;
using Domain;
using TestUtilities.Cryptography;

namespace TestUtilities.Entitties
{
    public class UserBuilder
    {
        public static User Build()
        {
            var passwordEncrypter = new PasswordEncripterBuilder().Build();

            return new Faker<User>()
                .RuleFor(u => u.Id, faker => faker.Random.Uuid())
                .RuleFor(u => u.Name, faker => faker.Person.FirstName)
                .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email(user.Name))
                .RuleFor(u => u.Password, (_, user) => passwordEncrypter.Encrypt(user.Password));
        }
    }
}
