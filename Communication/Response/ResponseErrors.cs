namespace Communication.Response;

public class ResponseErrors
{
    public List<string> Errors { get; private set; } = [];

    public ResponseErrors(params List<string> errors)
    {
        Errors = errors;
    }
}
