using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Application.Exceptions;
using ProjectX.Template.Domain.Common;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Categories.Commands.DeleteCategory {
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand> {
        private readonly IAsyncRepository<Category> _categoryRepository;

        public DeleteCategoryCommandHandler(IAsyncRepository<Category> categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {

            var validator = new DeleteEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new NotFoundException(nameof(Category), request.CategoryId);

            categoryToDelete.RecordStatus = RecordStatus.Passive;

            await _categoryRepository.UpdateAsync(categoryToDelete);

            return Unit.Value;
        }
    }
}
