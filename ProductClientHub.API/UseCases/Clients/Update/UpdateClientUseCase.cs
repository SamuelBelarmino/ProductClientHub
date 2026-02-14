using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionBase;
using ProductClientHub.Infrastructure;

namespace ProductClientHub.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {
        public void Execute (Guid clientId, RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.Clients.FirstOrDefault(c => c.Id == clientId);

            if (entity is null)
                throw new NotFoundException ("Cliente não encontrado");

            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.Idade = request.Idade;

            dbContext.Clients.Update(entity);
            dbContext.SaveChanges();
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
