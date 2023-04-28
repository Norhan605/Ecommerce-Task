using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Category;
using MediatR;

namespace Application.Features.Categories.Queries.FilterCategories
{
    public class FilterCategoriesQuery:IRequest<IEnumerable<CategoryMinimalDto>>
    {

        public string? Filter { get; set; }
    }
}
