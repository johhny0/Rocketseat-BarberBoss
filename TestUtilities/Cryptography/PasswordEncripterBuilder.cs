using Domain.Security.Cryptography;
using Moq;

namespace TestUtilities.Cryptography
{
    public class PasswordEncripterBuilder
    {
        private readonly Mock<IPasswordEncripter> _mock = new ();

        public PasswordEncripterBuilder()
        {
            _mock
                .Setup(pass => pass.Encrypt(It.IsAny<string>()))
                .Returns("p@ssw0rdEncrypt");
        }

        public void Verify(string password)
        {
            _mock
                .Setup(pass => pass.Verify(password, It.IsAny<string>()))
                .Returns(true);
        }

        public IPasswordEncripter Build()
        {
            return _mock.Object;
        }
    }
}
