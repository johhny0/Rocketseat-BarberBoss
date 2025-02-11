using Domain.Repositories.Users;
using Moq;

namespace TestUtilities.Repositories
{
    public class UsersWriteOnlyRepositoryBuilder
    {
        public static IUsersWriteOnlyRepository Build()
        {
            var mock = new Mock<IUsersWriteOnlyRepository>();


            return mock.Object;
        }
    }

}
