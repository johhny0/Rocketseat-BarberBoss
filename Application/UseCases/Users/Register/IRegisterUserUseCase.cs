using Communication.Request;
using Communication.Response;

namespace Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        ResponseUser Execute(RequestUser requestUser);
    }
}
