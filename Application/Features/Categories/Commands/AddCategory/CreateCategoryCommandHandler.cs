using Application.Contracts;
using Domain;
using Dtos.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.AddCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryMinimalDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryMinimalDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? parentCategory= null;
            if(request.ParentCategoryId!= null)
            {
                parentCategory=await _categoryRepository.GetDetailsAsync(request.ParentCategoryId.Value);
            }
            var category=new Category(request.Id, request.Name, parentCategory);
           category=await _categoryRepository.CreateAsync(category);
            return new CategoryMinimalDto() { ID = category.ID, Name = category.Name };
        }
    }
}
