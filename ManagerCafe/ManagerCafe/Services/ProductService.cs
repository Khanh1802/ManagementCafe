﻿using AutoMapper;
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

        public async Task DeleteAsync<Tkey>(Tkey key)
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
            var filters = await (await _productRepository.GetQueryableAsync())
             .Where(x => EF.Functions.Like(x.Name, $"%{item.Name}%"))
             .ToListAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(filters);
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

        public async Task<List<ProductDto>> FilterChoice(int filter)
        {
            if (Enum.IsDefined(typeof(EnumProductFilter), filter))
            {
                switch ((EnumProductFilter)filter)
                {
                    case EnumProductFilter.GiaTangDan:
                        return await FilterPriceAcs();
                    case EnumProductFilter.GiaGiamDan:
                        return await FilterPriceDesc();
                    case EnumProductFilter.NgayTangDan:
                        return await FilterDayAsc();
                    case EnumProductFilter.NgayGiamDan:
                        return await FilterDayDesc();
                }
            }
            return null;
        }
        public async Task<List<ProductDto>> GetAllAsync()
        {
            var entites = await _productRepository.GetAllAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(entites);
        }

        public async Task<ProductDto> GetByIdAsync<Tkey>(Tkey key)
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
    }
}