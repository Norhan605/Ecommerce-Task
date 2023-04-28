using Application.Features.Categories.Commands.AddCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.FilterCategories;
using Dtos.Category;
using InfaStructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Context context;
        private readonly IMediator mediator;
        public CategoryController(IMediator _mediator, Context context)
        {
            this.context = context;

            this.mediator = _mediator;
        }


        [HttpGet("asd")]
        public ActionResult GetAllCategory([FromBody]FilterCategoriesQuery query)
        {
           // var data=context.Categories.ToList();
            return Ok(mediator.Send(query));
        }

        [HttpGet("{id}")]
        public ActionResult GetCategoryByID(int id)
        {
            var Category = context.Categories.Where(c=>c.ID==id);
            return Ok(Category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryCommand command)
        {
           

            return Ok( await mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
        {

            return Ok(await mediator.Send(command));
        }
    }
}
