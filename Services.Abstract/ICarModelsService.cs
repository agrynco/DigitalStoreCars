using System.Threading.Tasks;
using Services.DTOs;
using Services.DTOs.Models;

namespace Services.Abstract
{
    public interface ICarModelsService
    {
        Task<PagedResult<GetModelsItemDto>> GetModels(GetModelsFilterDto filterDto);
    }
}