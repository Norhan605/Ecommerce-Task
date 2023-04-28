using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.AddCategory
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryCommand>
    {
      public CreateCategoryValidator() 
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(c => "Name Is requried")
                .NotNull().WithMessage(c => "Name Is requried")
                .MinimumLength(3).WithMessage(c => "must be more than 3 chars")
                .MaximumLength(200).WithMessage(c => "must not exceed 200 chars");
        }
    }
}
