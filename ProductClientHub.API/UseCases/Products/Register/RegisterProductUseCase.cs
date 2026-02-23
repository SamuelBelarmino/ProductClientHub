using ProductClientHub.API.UseCases.Products.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Domain.Entities;
using ProductClientHub.Exceptions.ExceptionBase;
using ProductClientHub.Infrastructure;

namespace ProductClientHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
        {
            var dbContext = new ProductClientHubDbContext();
            
            Validate(dbContext, clientId, request);

            var entity = new Product
            {               
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId    
            };

            dbContext.Products.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private void Validate(ProductClientHubDbContext dbContext, Guid clientId, RequestProductJson request)
        {
            var clientExist =  dbContext.Clients.Any(x => x.Id == clientId);

            if (!clientExist)           
                throw new NotFoundException("Esse cliente não existe");
            
            var validator = new RequestProductValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
