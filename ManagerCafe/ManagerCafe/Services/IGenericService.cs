using ManagerCafe.Commons;

namespace ManagerCafe.Services
{
    public interface IGenericService<TEntityDto, TCreateaDto, UpdateDto, FilterDto> where TEntityDto : class
    {
        Task<TEntityDto> AddAsync(TCreateaDto item);
        Task<List<TEntityDto>> GetAllAsync();
        Task<TEntityDto> UpdateAsync(UpdateDto item);
        Task DeleteAsync<Tkey>(Tkey key);
        Task<TEntityDto> GetByIdAsync<Tkey>(Tkey key);
        Task<List<TEntityDto>> FilterAsync(FilterDto item);
    }
}
