using ProductClientHub.Exceptions.ExceptionBase;
using ProductClientHub.Infrastructure;

namespace ProductClientHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.Clients.FirstOrDefault(c => c.Id == id);

            if (entity is null)
                throw new NotFoundException("Cliente não encontrado");

            dbContext.Clients.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
