using System.Net;

public class ConflictException : BaseException
{

    public ConflictException(string message) :
    base
        (
            "HSO-001", // código identificador de erros
            message,
            HttpStatusCode.Conflict,
            StatusCodes.Status409Conflict,
            null,
            DateTimeOffset.UtcNow,
            null
        )
    {
        throw new ConflictException("Customer already exists");
    }

}