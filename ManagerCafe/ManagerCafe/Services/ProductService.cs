using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.InventoryDtos;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Enums;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

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

        private async Task<IQueryable<Product>> FilterQueryAbleAsync(FilterProductDto item)
        {

            var query = await _productRepository.GetQueryableAsync();
            var filter = query.Where(x => !x.IsDeleted);
            return filter;
        }
        private async Task<CommonPageDto<ProductDto>> FilterDayAsc(FilterProductDto item)
        {
            var filter = (await FilterQueryAbleAsync(item))
                .OrderBy(x => x.CreateTime)
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount); ;
            var count = (await FilterQueryAbleAsync(item)).CountAsync();
            return new CommonPageDto<ProductDto>(await count, item, _mapper.Map<List<Product>, List<ProductDto>>(await filter.ToListAsync()));
        }

        private async Task<CommonPageDto<ProductDto>> FilterDayDesc(FilterProductDto item)
        {
            var filter = (await FilterQueryAbleAsync(item))
                .OrderByDescending(x => x.CreateTime)
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount); ;
            var count = (await FilterQueryAbleAsync(item)).CountAsync();
            return new CommonPageDto<ProductDto>(await count, item, _mapper.Map<List<Product>, List<ProductDto>>(await filter.ToListAsync()));
        }

        private async Task<CommonPageDto<ProductDto>> FilterPriceAcs(FilterProductDto item)
        {
            var filter = (await FilterQueryAbleAsync(item))
                .OrderBy(x => x.PriceSell)
                .Skip(item.SkipCount).Take(item.TakeMaxResultCount); ;
            var count = (await FilterQueryAbleAsync(item)).CountAsync();
            return new CommonPageDto<ProductDto>(await count, item, _mapper.Map<List<Product>, List<ProductDto>>(await filter.ToListAsync()));
        }

        private async Task<CommonPageDto<ProductDto>> FilterPriceDesc(FilterProductDto item)
        {
            var filter = (await FilterQueryAbleAsync(item))
                        .OrderByDescending(x => x.PriceSell)
                        .Skip(item.SkipCount).Take(item.TakeMaxResultCount); ;
            var count = (await FilterQueryAbleAsync(item)).CountAsync();
            return new CommonPageDto<ProductDto>(await count, item, _mapper.Map<List<Product>, List<ProductDto>>(await filter.ToListAsync()));
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

        public async Task<CommonPageDto<ProductDto>> GetPagedListAsync(FilterProductDto item, int choice)
        {
            switch ((EnumProductFilter)choice)
            {
                case EnumProductFilter.PriceAsc:
                    return await FilterPriceAcs(item);
                case EnumProductFilter.PriceDesc:
                    return await FilterPriceDesc(item);
                case EnumProductFilter.DateAsc:
                    return await FilterDayAsc(item);
                case EnumProductFilter.DateDesc:
                    return await FilterDayDesc(item);
            }
            return new CommonPageDto<ProductDto>();
        }

        public async Task<int> AllCountAsync()
        {
            return await (await _productRepository.GetQueryableAsync()).CountAsync();
        }
    }
}
