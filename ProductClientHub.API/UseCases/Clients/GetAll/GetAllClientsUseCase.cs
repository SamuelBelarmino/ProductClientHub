using ProductClientHub.Communication.Responses;
using ProductClientHub.Infrastructure;

namespace ProductClientHub.API.UseCases.Clients.GetAll
{
    public class GetAllClientsUseCase
    {
        public ResponseAllClientJson Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clients = dbContext.Clients
                .Select(c => new ResponseShortClientJson
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

            return new ResponseAllClientJson
            {
                Clients = clients
            };
        }

    }
}
