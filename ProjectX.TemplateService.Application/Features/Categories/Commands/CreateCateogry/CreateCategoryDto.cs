using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry {
    public class CreateCategoryDto {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public RecordStatus RecordStatus { get; set; }
    }
}
