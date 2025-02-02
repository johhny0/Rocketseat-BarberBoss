using Communication.Request;
using Communication.Response;

namespace Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        ResponseUser Execute(RequestLogin request);
    }
}
