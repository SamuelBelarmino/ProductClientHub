using ProductClientHub.Domain.Bases;

namespace ProductClientHub.Domain.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;   

        public int Age { get; set; }

       public List<Product> Products { get; set; } = new List<Product>();
    }
}
