using Bogus;
using Domain;
using Domain.Security.Tokens;
using Moq;

namespace TestUtilities.Token
{
    public class AccessTokenGeneratorBuilder
    {
        public static IAccessTokenGenerator Build()
        {
            var mock = new Mock<IAccessTokenGenerator>();

            mock
                .Setup(generator => generator.Generate(It.IsAny<User>()))
                .Returns("token");

            return mock.Object;
        }
    }
}
