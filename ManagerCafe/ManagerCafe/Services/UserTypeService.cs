using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Dtos.UserTypeDtos;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Buffers;

namespace ManagerCafe.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly ManagerCafeDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMemoryCache _memoryCache;

        public UserTypeService(ManagerCafeDbContext context, IMapper mapper, IUserTypeRepository userTypeRepository, IMemoryCache memoryCache)
        {
            _context = context;
            _mapper = mapper;
            _userTypeRepository = userTypeRepository;
            _memoryCache = memoryCache;
        }

        public async Task<UserTypeDto> AddAsync(CreateUserTypeDto item)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _userTypeRepository.AddAsync(_mapper.Map<CreateUserTypeDto, UserType>(item));
                transaction.Commit();
                return _mapper.Map<UserType, UserTypeDto>(user);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public async Task DeleteAsync(Guid key)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _userTypeRepository.GetByIdAsync(key);
                if (entity == null)
                {
                    throw new Exception("Not found User type to deleted");
                }
                await _userTypeRepository.Delete(entity);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }

        public Task<List<UserTypeDto>> FilterAsync(FilterUserTypeDto item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserTypeDto>> GetAllAsync()
        {
            if (_memoryCache.TryGetValue<List<UserType>>(UserTypeCacheKey.UserTypeAllKey, out var value))
            {
                return _mapper.Map<List<UserType>, List<UserTypeDto>>(value);
            }
            var allReuslt = await _userTypeRepository.GetAllAsync();
            _memoryCache.Set<List<UserType>>(UserTypeCacheKey.UserTypeAllKey, allReuslt, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            });
            return _mapper.Map<List<UserType>, List<UserTypeDto>>(await _userTypeRepository.GetAllAsync());
        }

        public async Task<UserTypeDto> GetByIdAsync(Guid key)
        {
            var entity = await _userTypeRepository.GetByIdAsync(key);
            return _mapper.Map<UserType, UserTypeDto>(entity);
        }

        public async Task<CommonPageDto<UserTypeDto>> GetPagedListAsync(FilterUserTypeDto item)
        {
            var query = (await _userTypeRepository.GetQueryableAsync());
            var filter = query.Where(x => !x.IsDeleted);
            var countAsync = filter.CountAsync();
            return new CommonPageDto<UserTypeDto>(await countAsync, item,
                _mapper.Map<List<UserType>, List<UserTypeDto>>(await filter.ToListAsync()));
        }

        public async Task<UserTypeDto> UpdateAsync(UpdateUserTypeDto item)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _userTypeRepository.GetByIdAsync(item.Id);
                if (entity == null)
                {
                    throw new Exception("Not found User type to update");
                }
                var update = await _userTypeRepository.UpdateAsync(_mapper.Map<UpdateUserTypeDto, UserType>(item, entity));
                transaction.Commit();
                return _mapper.Map<UserType, UserTypeDto>(update);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }
    }
}
