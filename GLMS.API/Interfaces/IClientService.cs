using GLMS.API.Models;

namespace GLMS.API.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}
