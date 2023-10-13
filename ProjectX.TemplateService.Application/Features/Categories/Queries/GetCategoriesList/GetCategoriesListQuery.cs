using MediatR;

namespace ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesList {
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>> {
    }
}
