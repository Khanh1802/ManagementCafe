using AutoMapper;
using ManagerCafe.CacheItems.Users;
using ManagerCafe.Commons;
using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.UsersDto;
using ManagerCafe.Dtos.UsersDtos.ValidateUserDto;
using ManagerCafe.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerCafe.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ManagerCafeDbContext _contex;
        private readonly IMapper _mapper;
        private readonly IUserValidate _userValidate;
        private readonly IUserCacheService _userCacheService;

        public UserService(IUserRepository userRepository,
            IMapper mapper, IUserValidate userValidate,
            IUserCacheService userCacheService, ManagerCafeDbContext contex)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userValidate = userValidate;
            _userCacheService = userCacheService;
            _contex = contex;
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
                item.UserName = entity.UserName;
                if(item.Password == null)
                {
                    item.Password = entity.Password;
                }
                var update = _mapper.Map<UpdateUserDto, User>(item, entity);
                await _userRepository.UpdateAsync(update);
                await transaction.CommitAsync();
                _userCacheService.Set(_mapper.Map<User, UserCacheItem>(update));
                return _mapper.Map<User, UserDto>(update);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex.GetBaseException();
            }
        }




        public async Task<bool> LoginAsync(string userName, string password)
        {
            var hashingPassword = CommonCreateMD5.Create(password);
            var user = await (await _userRepository.GetQueryableAsync())
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserName == userName && x.Password == hashingPassword);

            if (user != null)
            {
                //Update last login
                user.LastLoginTime = DateTime.Now;
                await _userRepository.UpdateAsync(user);

                //Add to cache
                _userCacheService.Set(_mapper.Map<User, UserCacheItem>(user));

                return true;
            }

            return false;
        }

        public async Task<bool> CheckUserNameExistAysnc(string item)
        {
            var query = await _userRepository.GetQueryableAsync();
            return await query.AnyAsync(x => x.UserName == item);
        }

        public async Task<bool> ChangePassword(string passwordOld, string passwordNew, string passwordNewRepeat)
        {
            var user = _userCacheService.GetOrDefault();
            string hashingPasswordOld = CommonCreateMD5.Create(passwordOld);

            var account = await (await _userRepository.GetQueryableAsync()).AsNoTracking()
                .Where(x => x.Id == user.Id && x.Password == hashingPasswordOld)
                .SingleOrDefaultAsync();
            if (account == null)
            {
                throw new Exception("Password old not correct");
            }
            if (passwordNew != passwordNewRepeat)
            {
                throw new Exception("Password new not same type");
            }
            string hashingPasswordNew = CommonCreateMD5.Create(passwordNew);
            string hashingPasswordNewRepeat = CommonCreateMD5.Create(passwordNewRepeat);

            var update = new UpdateUserDto()
            {
                Id = account.Id,
                FullName = account.FullName,
                Email = account.Email,
                PhoneNumber = account.PhoneNumber,
                Password = hashingPasswordNew,
                UserName = account.UserName,
                UserTypeId = account.UserTypeId
            };
            try
            {
                await UpdateAsync(update);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
