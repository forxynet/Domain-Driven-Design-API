using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesList {
    public class CategoryListVm {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public RecordStatus RecordStatus { get; init; }
    }
}
