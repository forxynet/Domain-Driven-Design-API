using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesListWithEvents {
    public class CategoryEventListVm {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CategoryEventDto>? Events { get; set; }
        public RecordStatus RecordStatus { get; init; }
    }
}
