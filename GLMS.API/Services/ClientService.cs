using GLMS.API.Data;
using GLMS.API.Interfaces;
using GLMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GLMS.API.Services
{
    public class ClientService : IClientService
    {
        private readonly GLMSDbContext _context;

        public ClientService(GLMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task CreateAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
