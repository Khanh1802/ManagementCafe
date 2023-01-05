using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProductDto> AddAsync(CreateProductDto item)
        {
            var entity = _mapper.Map<CreateProductDto, Product>(item);
            await _productRepository.AddAsync(entity);
            return _mapper.Map<Product, ProductDto>(entity);
        }

        public async Task DeleteAsync<TKey>(TKey key)
        {
            var entity = await _productRepository.GetByIdAsync(key);
            if (entity is null)
            {
                throw new Exception("Not found Product to delete");
            }
            await _productRepository.Delete(entity);
        }

        public async Task<List<ProductDto>> FilterAsync(FilterProductDto item)
        {
            //var filters = await (await _productRepository.GetQueryableAsync())
            // .Where(x => EF.Functions.Like(x.Name, $"%{item.Name}%"))
            // .ToListAsync();

            var filters = await _productRepository.GetQueryableAsync();

            if (!string.IsNullOrEmpty(item.Name))
            {
                filters = filters.Where(x => EF.Functions.Like(x.Name, $"%{item.Name}%"));
            }

            if (item.PriceBuy > 0)
            {
                filters = filters.Where(x => x.PriceBuy == item.PriceBuy);
            }

            if (item.PriceSell > 0)
            {
                filters = filters.Where(x => x.PriceSell == item.PriceSell);
            }

            return _mapper.Map<List<Product>, List<ProductDto>>(await filters.ToListAsync());
        }

        private async Task<List<ProductDto>> FilterDayAsc()
        {
            var products = await (await _productRepository.GetQueryableAsync())
              .OrderBy(x => x.CreateTime).ToListAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        private async Task<List<ProductDto>> FilterDayDesc()
        {
            var products = await (await _productRepository.GetQueryableAsync())
              .OrderByDescending(x => x.CreateTime).ToListAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        private async Task<List<ProductDto>> FilterPriceAcs()
        {
            var products = await (await _productRepository.GetQueryableAsync())
                .OrderBy(x => x.PriceSell).ToListAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        private async Task<List<ProductDto>> FilterPriceDesc()
        {
            var products = await (await _productRepository.GetQueryableAsync())
                 .OrderByDescending(x => x.PriceSell).ToListAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public async Task<List<ProductDto>> FilterChoice(EnumProductFilter filter)
        {
            switch (filter)
            {
                case EnumProductFilter.PriceAsc:
                    return await FilterPriceAcs();
                case EnumProductFilter.PriceDesc:
                    return await FilterPriceDesc();
                case EnumProductFilter.DateAsc:
                    return await FilterDayAsc();
                case EnumProductFilter.DateDesc:
                    return await FilterDayDesc();
            }

            throw new Exception("Not found filter Product");
        }
        public async Task<List<ProductDto>> GetAllAsync()
        {
            var entites = await _productRepository.GetAllAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(entites);
        }

        public async Task<ProductDto> GetByIdAsync<TKey>(TKey key)
        {
            var entity = await _productRepository.GetByIdAsync(key);
            return _mapper.Map<Product, ProductDto>(entity);
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductDto item)
        {
            var entity = await _productRepository.GetByIdAsync(item.Id);
            if (entity is null)
            {
                throw new Exception("Not found Product to update");
            }
            var update = _mapper.Map<UpdateProductDto, Product>(item, entity);
            await _productRepository.UpdateAsync(update);
            return _mapper.Map<Product, ProductDto>(update);
        }

        public async Task<CommonPageDto<ProductDto>> GetPagedListAsync(FilterProductDto item)
        {
            var productQueryable = await _productRepository.GetQueryableAsync();
            //Xu ly du lieu filter
            var count = await productQueryable.CountAsync();
            var product = await productQueryable.OrderBy(x => x.CreateTime).Skip(item.SkipCount).Take(item.MaxResultCount).ToListAsync();
            // thieu oder
            return new CommonPageDto<ProductDto>(
                count, item, _mapper.Map<List<Product>, List<ProductDto>>(product));
        }

        public async Task<int> AllCountAsync()
        {
            return await (await _productRepository.GetQueryableAsync()).CountAsync();
        }
    }
}
