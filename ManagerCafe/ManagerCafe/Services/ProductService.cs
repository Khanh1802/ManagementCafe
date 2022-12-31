using AutoMapper;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Repositories;

namespace ManagerCafe.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto item)
        {
            var entity = _mapper.Map<CreateProductDto, Product>(item);
            await _productRepository.AddAsync(entity);
            return _mapper.Map<Product, ProductDto>(entity);
        }

        public async Task DeleteAsync<Tkey>(Tkey key)
        {
            var entity = await _productRepository.GetById(key);
            if (entity is null)
            {
                throw new Exception("Not found Product to delete");
            }
            await _productRepository.Delete(entity);
        }

        public Task<List<ProductDto>> FilterAsync(FilterProductDto item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var entites = await _productRepository.GetAllAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(entites);
        }

        public async Task<ProductDto> GetByIdAsync<Tkey>(Tkey key)
        {
            var entity = await _productRepository.GetById(key);
            return _mapper.Map<Product, ProductDto>(entity);
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductDto item)
        {
            var entity = await _productRepository.GetById(item.Id);
            if (entity is null)
            {
                throw new Exception("Not found Product to update");
            }
            var update = _mapper.Map<UpdateProductDto, Product>(item, entity);
            await _productRepository.UpdateAsync(update);
            return _mapper.Map<Product, ProductDto>(update);
        }
    }
}
