using Bogus;
using Communication.Request;

namespace UnitTest.Builder
{
    public class UserRegisterBuilder
    {
        public static RequestUser Build()
        {
            return new Faker<RequestUser>()
                .RuleFor(u => u.Name, f => f.Person.FirstName)
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(u => u.Password, f => f.Internet.Password(prefix: "!Aa1"));
        }
    }
}
