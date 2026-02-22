using Application.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Products.GetProductById
{
    public class GetProductByIdUseCase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdUseCase(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto?> ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _repository.GetByIdAsync(id, cancellationToken);
            
            if (product is null)
                return null;

            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}
