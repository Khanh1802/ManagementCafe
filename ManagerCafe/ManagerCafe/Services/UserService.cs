using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Dtos.UsersDtos.ValidateUserDto;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Transactions;

namespace ManagerCafe.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeService _userTypeService;
        private readonly ManagerCafeDbContext _contex;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IUserValidate _userValidate;

        public UserService(IUserRepository userRepository, IMapper mapper, ManagerCafeDbContext contex, IUserTypeService userTypeService, IMemoryCache memoryCache, IUserValidate userValidate)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contex = contex;
            _userTypeService = userTypeService;
            _memoryCache = memoryCache;
            _userValidate = userValidate;
        }

        public async Task<UserDto> AddAsync(CreateUserDto item)
        {
            var transaction = await _contex.Database.BeginTransactionAsync();
            try
            {
                if (await CheckUserNameExistAysnc(item.UserName) != false)
                {
                    throw new Exception("User name have been already exist");
                }

                if (await _userValidate.IsValidateEmailAsync(item))
                {
                    throw new Exception("Email have been already exist");
                }

                if (await _userValidate.IsValidatePhoneNumberAsync(item))
                {
                    throw new Exception("Phone number have been already exist");
                }

                var stringMD5 = CommonCreateMD5.Create(item.Password);
                item.Password = stringMD5;
                var user = await _userRepository.AddAsync(_mapper.Map<CreateUserDto, User>(item));
                await transaction.CommitAsync();
                return _mapper.Map<User, UserDto>(user);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }

        public async Task DeleteAsync<Tkey>(Tkey key)
        {
            var transaction = await _contex.Database.BeginTransactionAsync();
            try
            {
                var entity = await _userRepository.GetByIdAsync(key);
                if (entity == null)
                {
                    throw new Exception("Not found User to deleted");
                }
                await _userRepository.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public Task<List<UserDto>> FilterAsync(FilterUserDto item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return _mapper.Map<List<User>, List<UserDto>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserDto> GetByIdAsync<Tkey>(Tkey key)
        {
            return _mapper.Map<User, UserDto>(await _userRepository.GetByIdAsync(key));
        }

        public async Task<UserDto> UpdateAsync(UpdateUserDto item)
        {
            var transaction = await _contex.Database.BeginTransactionAsync();
            try
            {
                var entity = await _userRepository.GetByIdAsync(item.Id);
                if (entity == null)
                {
                    throw new Exception("Not found User to update");
                }

                var update = _mapper.Map<UpdateUserDto, User>(item, entity);
                await _userRepository.UpdateAsync(update);
                await transaction.CommitAsync();
                return _mapper.Map<User, UserDto>(update);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }

        public async Task<User> LoginAccountAsync(UserDto item)
        {
            item.Password = CommonCreateMD5.Create(item.Password);
            var account = (await _userRepository.GetQueryableAsync());
            account = account.Where(x => x.UserName == item.UserName && x.Password == item.Password);
            var user = await account.SingleOrDefaultAsync();
            return user;
        }

        public async Task<bool> CheckUserNameExistAysnc(string item)
        {
            var query = await _userRepository.GetQueryableAsync();
            return await query.AnyAsync(x => x.UserName == item);
        }
    }
}
