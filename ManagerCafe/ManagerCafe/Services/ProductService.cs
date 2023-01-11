using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ManagerCafe.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductService(IProductRepository productRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
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
                filters = filters.Where(x => EF.Functions.Match(x.Name, $"*{item.Name}*", MySqlMatchSearchMode.Boolean));
            }

            if (item.PriceBuy > 0)
            {
                filters = filters.Where(x => x.PriceBuy == item.PriceBuy);
            }

            if (item.PriceSell > 0)
            {
                filters = filters.Where(x => x.PriceSell == item.PriceSell);
            }
            // Hướng vẫn cách xem query
            //var query = filters.ToQueryString();
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
            // Get dữ liệu sau khi Set hay còn gọi là cache
            //Đọc dữ liệu trong cache ra
            if (_memoryCache.TryGetValue<List<Product>>(ProductCacheKey.ProductAllKey, out var products))
            {
                return _mapper.Map<List<Product>, List<ProductDto>>(products);
            }

            var entites = await _productRepository.GetAllAsync();

            //Set lại cache với thời gian hết hạn bắt đầu từ bây giờ 2m
            // NOTE: Khi add và update nên dùng remove theo Key để build lại cache 
            _memoryCache.Set<List<Product>>(ProductCacheKey.ProductAllKey, entites, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            });
            return _mapper.Map<List<Product>, List<ProductDto>>(entites);
        }

        public async Task<ProductDto> GetByIdAsync<TKey>(TKey key)
        {
            if (_memoryCache.TryGetValue<Product>(key, out var product))
            {
                return _mapper.Map<Product, ProductDto>(product);
            }
            var entity = await _productRepository.GetByIdAsync(key);
            _memoryCache.Set<Product>(key, entity, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            });
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
            var count = await productQueryable.CountAsync(); 
            var product = await productQueryable.OrderBy(x => x.CreateTime).Skip(item.SkipCount).Take(item.TakeMaxResultCount).ToListAsync();
            var produts = new CommonPageDto<ProductDto>(
                count, item, _mapper.Map<List<Product>, List<ProductDto>>(product)); 
            return produts;
        }

        public async Task<int> AllCountAsync()
        {
            return await (await _productRepository.GetQueryableAsync()).CountAsync();
        }
    }
}
