namespace Domain.Repositories.Users
{
    public interface IUsersUpdateOnlyRepository
    {
        User? GetById(Guid id);
        void Update(User user);
    }
}
