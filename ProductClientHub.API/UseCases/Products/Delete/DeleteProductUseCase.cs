using ProductClientHub.Exceptions.ExceptionBase;
using ProductClientHub.Infrastructure;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id) 
        {
            var dbContext = new ProductClientHubDbContext();
            
            var entity = dbContext.Products.FirstOrDefault(p => p.Id == id);

            if(entity is null)
                throw new NotFoundException("Produto não encontrado");

            dbContext.Products.Remove(entity);  

            dbContext.SaveChanges();
        }
    }
}
