using AutoMapper;
using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Application.Exceptions;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Categories.Commands.UpdateCategory {
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand> {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IMapper maper, IAsyncRepository<Category> category) {
            _mapper = maper;
            _categoryRepository = category;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken) {
            var validator = new UpdateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0) {
                throw new ValidationException(validationResult);
            }

            var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new NotFoundException(nameof(Category), request.CategoryId);

            _mapper.Map(request, categoryToUpdate, typeof(UpdateCategoryCommand), typeof(Category));

            await _categoryRepository.UpdateAsync(categoryToUpdate);

            return Unit.Value;
        }
    }
}
