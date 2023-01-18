using AutoMapper;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ManagerCafe.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeService _userTypeService;
        private readonly ManagerCafeDbContext _contex;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, ManagerCafeDbContext contex, IUserTypeService userTypeService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contex = contex;
            _userTypeService = userTypeService;
        }

        public async Task<User> CheckPassword(UserDto item)
        {
            var password = CommonCreateMD5.Create(item.Password);
            var query = (await _userRepository.GetQueryableAsync());
            query = query.Where(x => x.UserName == item.UserName && x.Password == password);
            return query.SingleOrDefault();
        }
        public async Task<User> CheckUserName(string input)
        {
            var query = (await _userRepository.GetQueryableAsync());
            var filter = query.Where(x => x.UserName == input);
            return await filter.SingleOrDefaultAsync();
        }

        private bool CheckEmail(string input)
        {
            string[] subs = input.Split("@");
            if (subs.Length > 2)
            {
                throw new Exception("Check emai again");
            }
            var filter = subs[1].Equals("gmail.com");
            return filter;
        }

        private bool CheckPhoneNumer(string input)
        {
            var filter = decimal.TryParse(input, out var number);
            return filter;
        }

        public async Task<UserDto> AddAsync(CreateUserDto item)
        {
            var transaction = await _contex.Database.BeginTransactionAsync();
            try
            {
                var stringMD5 = CommonCreateMD5.Create(item.Password);
                item.Password = stringMD5;
                var checkEmail = CheckEmail(item.Email);
                var checkUserName = await CheckUserName(stringMD5);
                var checkPhoneNumer = CheckPhoneNumer(item.PhoneNumber);
                if (checkUserName == null)
                {
                    throw new Exception("Name user have been already");
                }
                if (!checkEmail)
                {
                    throw new Exception("Your email don't have @gmail.com");
                }
                if (checkPhoneNumer == false)
                {
                    throw new Exception("Have a char in your phone number");
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

        public async Task<User> LoginAccount(UserDto item)
        {
            var UserName = await CheckUserName(item.UserName);
            if (UserName == null)
            {
                throw new Exception("Not found user name");
            }
            var login = await CheckPassword(item);
            if (login == null)
            {
                throw new Exception("Login failed\nCheck password or user name");
            }
            return login;
        }
    }
}
