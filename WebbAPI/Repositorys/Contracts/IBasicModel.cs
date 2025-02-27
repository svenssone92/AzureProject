using WebbAPI.DTOs;
using WebbAPI.Models;

namespace WebbAPI.Repositorys.Contracts
{
    public interface IBasicModel
    {
        Task<BasicModelDTO> GetBasicModel(int id);
        Task<IEnumerable<BasicModelDTO>> GetAllBasicModelsAsync();
        Task<BasicModel> AddBasicModelAsync(BasicModelDTO basicModelDto);
        Task DeleteBasicModelAsync(int id);
        Task UpdateModel(BasicModelDTO basicModelDto);
    }
}
