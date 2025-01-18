using Domain;
using Domain.Repositories.Users;

namespace Infraestructure.DataAccess.Repositories
{
    internal class UsersRepository(BarberBossDbContext dbContext) : IUsersReadOnlyRepository, IUsersWriteOnlyRepository, IUsersUpdateOnlyRepository, IUsersRemoveOnlyRepository
    {
        public void Add(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public bool ExistUserWithEmail(string email)
        {
            return dbContext.Users.Any(u => u.Email == email);
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User billing)
        {
            throw new NotImplementedException();
        }
    }
}
