using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public class NotFoundException : ProductClientHubException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }

        public override List<string> GetErrors() => new List<string> { Message };

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
    }
}
