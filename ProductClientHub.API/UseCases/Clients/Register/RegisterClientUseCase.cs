using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Domain.Entities;
using ProductClientHub.Exceptions.ExceptionBase;
using ProductClientHub.Infrastructure;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseShortClientJson Execute(RequestClientJson request)
        {
            Validate(request);
            
            var dbContext = new ProductClientHubDbContext();

            var entity = new Client
            {
                Id = Guid.NewGuid(), //pode ser gerado na classe de domínio ou aqui, dependendo da arquitetura
                Name = request.Name,
                Email = request.Email,
                Idade = request.Idade
            };

            dbContext.Clients.Add(entity);

            dbContext.SaveChanges();

            return new ResponseShortClientJson
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
