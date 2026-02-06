using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : ProductClientHubException
    {
        private readonly List<string> _errors;
        //readonly só pode ser atribuído valor no construtor, ou seja, o valor é atribuído quando a classe é instanciada, e não pode ser alterado depois.
        //quando for private e readonly, o nome da variavel começa com _

        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrors() => _errors;

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
