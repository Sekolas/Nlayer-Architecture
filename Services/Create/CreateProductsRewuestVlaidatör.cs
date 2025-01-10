using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Create
{

    public class CreateProductsRewuestVlaidatör : AbstractValidator<CreateProductRequest>
    {
        public CreateProductsRewuestVlaidatör()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .Length(3, 10).WithMessage("Name must be between 3-10 characters");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.stock).InclusiveBetween(1, 100).WithMessage("Stock must be between 1-100");
        }
    }
}
