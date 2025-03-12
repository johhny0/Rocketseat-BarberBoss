using Domain;
using Domain.Repositories.Users;
using Moq;

namespace TestUtilities.Repositories
{
    public class UsersReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUsersReadOnlyRepository> _repository;

        public UsersReadOnlyRepositoryBuilder()
        {
            _repository = new Mock<IUsersReadOnlyRepository>();
        }

        public void ExistUserWithEmail(string email)
        {
            _repository
                .Setup(repos => repos.ExistUserWithEmail(email))
                .Returns(true);
        }

        public void GetByEmail(User user)
        {
            _repository
                .Setup(repos => repos.GetByEmail(user.Email))
                .Returns(user);
        }

        public IUsersReadOnlyRepository Build() => _repository.Object;
    }
}
