using Application.Contracts;
using Dtos.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.FilterCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<FilterCategoriesQuery, IEnumerable<CategoryMinimalDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryMinimalDto>> Handle(FilterCategoriesQuery request, CancellationToken cancellationToken)
        {
            return (await _categoryRepository.FilterByAsync(request.Filter))
                  .Select(a=> new CategoryMinimalDto{ID = a.ID, Name = a.Name });
        }
    }
}
