using GLMS.API.Models;
using GLMS.Models;

namespace GLMS.API.Interfaces
{
    public interface IContractService
    {
        Task<List<ContractDto>> GetContractsAsync(
            string? status,
            DateTime? startDate,
            DateTime? endDate);

        Task<ContractDto?> GetByIdAsync(int id);

        Task<ContractDto> CreateAsync(ContractDto contract);

        Task UpdateAsync(int id, ContractDto contract);

        Task DeleteAsync(int id);

        Task UpdateStatusAsync(int id, string status);

        Task UploadAgreementAsync(int id, IFormFile file);

        Task<string> DownloadAgreementAsync(int id);
    }
}