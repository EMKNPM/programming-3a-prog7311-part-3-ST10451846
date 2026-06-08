using GLMS.API.Models;
using GLMS.Models;
using GLMS.Shared.DTOs;
using System.Threading.Tasks;

namespace GLMS.API.Interfaces
{
    public interface IServiceRequestService
    {
        Task<List<ServiceRequestDto>> GetAllAsync();
        Task<ServiceRequestDto?> GetByIdAsync(int id);
        Task<ServiceRequestDto> CreateAsync(ServiceRequestDto dto);
        Task UpdateAsync(ServiceRequestDto dto);
        Task DeleteAsync(int id);
        Task<decimal> ConvertUsdToZar(decimal usd);
    }
}
