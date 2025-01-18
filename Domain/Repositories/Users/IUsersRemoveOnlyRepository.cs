namespace Domain.Repositories.Users
{
    public interface IUsersRemoveOnlyRepository
    {
        bool Remove(Guid id);
    }
}
