using Dtos.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.AddCategory
{
    public class CreateCategoryCommand:IRequest<CategoryMinimalDto>
    {
      public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public CreateCategoryCommand(int id, string name, int? parentCategoryId=null)
        {
            Id = id;
            Name = name;
            ParentCategoryId = parentCategoryId;
        }
    }
}
