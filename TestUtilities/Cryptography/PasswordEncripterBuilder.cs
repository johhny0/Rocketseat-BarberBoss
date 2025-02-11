using Domain.Security.Cryptography;
using Moq;

namespace TestUtilities.Cryptography
{
    public class PasswordEncripterBuilder
    {
        public static IPasswordEncripter Build()
        {
            var mock = new Mock<IPasswordEncripter>();

            mock
                .Setup(pass => pass.Encrypt(It.IsAny<string>()))
                .Returns("p@ssw0rdEncrypt");

            return mock.Object;
        }
    }
}
