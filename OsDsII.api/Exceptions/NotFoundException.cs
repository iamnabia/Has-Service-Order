using System.Net;

namespace OsDsII.api.Exceptions
{
    public sealed class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base
            (
                "HSO-002", //0 - 400 1 - 500
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                null,
                DateTimeOffset.UtcNow,
                null
            )
        { }

    }
}
