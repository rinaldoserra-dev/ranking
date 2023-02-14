using MediatR;
using Microsoft.AspNetCore.Mvc;
using RS.Ranking.Catalog.Application.UseCases.Category.Common;
using RS.Ranking.Catalog.Application.UseCases.Category.ListCategories;
using RS.Ranking.Catalog.Domain.SeedWork.SearchableRepository;

namespace RS.Ranking.Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
            => _mediator = mediator;


        [HttpGet]
        [ProducesResponseType(typeof(ListCategoriesOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(
            CancellationToken cancellationToken,
            [FromQuery] int? page = null,
            [FromQuery(Name = "per_page")] int? perPage = null,
            [FromQuery] string? search = null,
            [FromQuery] string? sort = null,
            [FromQuery] SearchOrder? dir = null
        )
        {
            var input = new ListCategoriesInput();
            if (page is not null) input.Page = page.Value;
            if (perPage is not null) input.PerPage = perPage.Value;
            if (!String.IsNullOrWhiteSpace(search)) input.Search = search;
            if (!String.IsNullOrWhiteSpace(sort)) input.Sort = sort;
            if (dir is not null) input.Dir = dir.Value;

            var output = await _mediator.Send(input, cancellationToken);
            return Ok(
                (output)
            );
        }
    }
}