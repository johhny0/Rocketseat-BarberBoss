namespace Domain.Repositories.Users
{
    public interface IUsersReadOnlyRepository
    {
        bool ExistUserWithEmail(string email);
        List<User> GetAll();
        User? GetByEmail(string email);
        User? GetById(Guid id);
    }
}
