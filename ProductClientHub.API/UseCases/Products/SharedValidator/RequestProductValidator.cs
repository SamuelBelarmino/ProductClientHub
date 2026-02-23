using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("É necessário preencher o nome do produto");

            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage("É necessário preencher o nome da marca do produto");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("O preço do produto deve ser maior que 0,00");
        }
    }
}
