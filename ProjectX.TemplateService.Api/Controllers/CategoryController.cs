using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry;
using ProjectX.Template.Application.Features.Categories.Commands.DeleteCategory;
using ProjectX.Template.Application.Features.Categories.Commands.UpdateCategory;
using ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesList;
using ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

namespace ProjectX.Template.Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories() {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory) {
            GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery() { IncludeHistory = includeHistory };

            var dtos = await _mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(dtos);
        }

        //[Authorize]
        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> AddCategory([FromBody] CreateCategoryCommand createCategoryCommand) {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        //[Authorize]
        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand updateCategoryCommand) {
            await _mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        //[Authorize]
        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCategory(Guid id) {
            var deleteCategoryCommand = new DeleteCategoryCommand() { CategoryId = id };
            await _mediator.Send(deleteCategoryCommand);
            return NoContent();
        }
    }
}