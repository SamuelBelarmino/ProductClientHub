using Microsoft.EntityFrameworkCore;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;
using ProductClientHub.Infrastructure;

namespace ProductClientHub.API.UseCases.Clients.GetById
{
    public class GetClientByIdUseCase
    {
        public ResponseClientJson Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext
                .Clients
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);

            if (entity is null) 
                throw new NotFoundException("Cliente não encontrado.");

            return new ResponseClientJson
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Products = entity.Products.Select(p => new ResponseShortProductJson
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList()
            };
        }
    }
}
