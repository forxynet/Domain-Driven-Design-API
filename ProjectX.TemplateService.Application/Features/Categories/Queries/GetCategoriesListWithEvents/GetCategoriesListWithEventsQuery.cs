using MediatR;

namespace ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesListWithEvents {
    public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListVm>> {
        public bool IncludeHistory { get; set; }
    }
}
