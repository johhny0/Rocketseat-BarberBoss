using Bogus;
using Communication.Request;

namespace TestUtilities.Communication
{
    public class RequestLoginBuilder
    {
        public static RequestLogin Build()
        {
            return new Faker<RequestLogin>()
                .RuleFor(user => user.Email, faker => faker.Internet.Email())
                .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa1"));
        }
    }
}
