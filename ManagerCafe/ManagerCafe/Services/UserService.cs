using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
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

        private string _userName;

        public UserService(IUserRepository userRepository, IMapper mapper, ManagerCafeDbContext contex, IUserTypeService userTypeService, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contex = contex;
            _userTypeService = userTypeService;
            _memoryCache = memoryCache;
        }

        public async Task<bool> CheckUserNameExistAysnc(string input)
        {
            var query = (await _userRepository.GetQueryableAsync());
            var filter = query.AnyAsync(x => x.UserName == input);
            return await filter;
        }

        private bool CheckEmailConvert(string input)
        {
            string[] subs = input.Split("@");
            if (subs.Length > 2)
            {
                throw new Exception("Check emai again");
            }
            var filter = subs[1].Equals("gmail.com");
            return filter;
        }

        private string CheckPhoneNumerConvert(string input)
        {
            var checkInput = input.StartsWith("0") || input.StartsWith("84");
            if (checkInput)
            {
                if (input.StartsWith("84"))
                {
                    input = "0" + input.Substring(2);
                }
                var filter = decimal.TryParse(input, out var number);
                if (filter && input.Length == 10)
                {
                    return input;
                }
            }
            return null;
        }

        public async Task<bool> CheckEmailExistAsync(string input)
        {
            var query = (await _userRepository.GetQueryableAsync());
            var filter = query.AnyAsync(x => x.Email == input);
            return await filter;
        }

        public async Task<bool> CheckPhoneExistAsync(string input)
        {
            var query = (await _userRepository.GetQueryableAsync());
            var filter = query.AnyAsync(x => x.PhoneNumber == input);
            return await filter;
        }

        public async Task<UserDto> AddAsync(CreateUserDto item)
        {
            var transaction = await _contex.Database.BeginTransactionAsync();
            try
            {
                var stringMD5 = CommonCreateMD5.Create(item.Password);
                item.Password = stringMD5;
                var checkEmailConvert = CheckEmailConvert(item.Email);
                if (!checkEmailConvert)
                {
                    throw new Exception("Your email don't have @gmail.com");
                }
                var checkPhoneNumerConvert = CheckPhoneNumerConvert(item.PhoneNumber);

                if (checkPhoneNumerConvert == null)
                {
                    throw new Exception("Check phone again");
                }

                item.PhoneNumber = CheckPhoneNumerConvert(item.PhoneNumber);

                var checkUserNameExist = await CheckUserNameExistAysnc(item.UserName);
                if (checkUserNameExist != false)
                {
                    throw new Exception("User name have been already exist");
                }
                var checkEmailExist = await CheckEmailExistAsync(item.Email);
                if (checkEmailExist != false)
                {
                    throw new Exception("Email have been already exist");
                }
                var checkPhoneExist = await CheckPhoneExistAsync(item.PhoneNumber);
                if (checkPhoneExist != false)
                {
                    throw new Exception("Phone number have been already exist");
                }
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
    }
}
