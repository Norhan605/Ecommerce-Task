using Application.Contracts;
using Domain;
using Dtos.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api.V5;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetDetailsAsync(request.Id);
            if(category== null)
            {
                return false;
            }
            else
            {
                category.Name= request.Name;
                return await _categoryRepository.UpdateAsync(category);
            }
        }

        //public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        //{
        //    var category =await _categoryRepository.GetDetailsAsync(request.Id);
        //    if(category == null)
        //    {
        //        return null;

        //    }
        //    category.ID = request.Id;
        //    category.Name = request.Name;

        //    _categoryRepository.UpdateAsync(category);
        //    return new UpdateCategoryDto { ID = request.Id,Name = request.Name };
        //}
    }
}
