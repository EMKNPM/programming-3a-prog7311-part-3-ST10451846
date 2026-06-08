using GLMS.API.Data;
using GLMS.API.Interfaces;
using GLMS.API.Models;
using GLMS.Models;
using GLMS.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GLMS.API.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly GLMSDbContext _context;

        public ServiceRequestService(GLMSDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET ALL
        // =========================
        public async Task<List<ServiceRequestDto>> GetAllAsync()
        {
            return await _context.ServiceRequests
                .Select(r => new ServiceRequestDto
                {
                    Id = r.Id,
                    ContractId = r.ContractId,
                    Description = r.Description,
                    USDAmount = r.USDAmount,
                    ZARAmount = r.ZARAmount,
                    ServiceType = r.ServiceType
                })
                .ToListAsync();
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<ServiceRequestDto?> GetByIdAsync(int id)
        {
            return await _context.ServiceRequests
                .Where(r => r.Id == id)
                .Select(r => new ServiceRequestDto
                {
                    Id = r.Id,
                    ContractId = r.ContractId,
                    Description = r.Description,
                    USDAmount = r.USDAmount,
                    ZARAmount = r.ZARAmount,
                    ServiceType = r.ServiceType
                })
                .FirstOrDefaultAsync();
        }

        // =========================
        // CREATE
        // =========================
        public async Task<ServiceRequestDto> CreateAsync(ServiceRequestDto dto)
        {
            var entity = new ServiceRequest
            {
                ContractId = dto.ContractId,
                Description = dto.Description,
                USDAmount = dto.USDAmount,
                ZARAmount = dto.USDAmount * 18.5m, // conversion fix
                ServiceType = dto.ServiceType
            };

            _context.ServiceRequests.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.ZARAmount = entity.ZARAmount;

            return dto;
        }

        // =========================
        // UPDATE
        // =========================
        public async Task UpdateAsync(ServiceRequestDto dto)
        {
            var entity = await _context.ServiceRequests.FindAsync(dto.Id);

            if (entity == null)
                throw new Exception("Service request not found");

            entity.ContractId = dto.ContractId;
            entity.Description = dto.Description;
            entity.USDAmount = dto.USDAmount;
            entity.ZARAmount = dto.USDAmount * 18.5m;
            entity.ServiceType = dto.ServiceType;

            await _context.SaveChangesAsync();
        }

        // =========================
        // DELETE
        // =========================
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ServiceRequests.FindAsync(id);

            if (entity == null) return;

            _context.ServiceRequests.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // =========================
        // USD → ZAR
        // =========================
        public Task<decimal> ConvertUsdToZar(decimal usd)
        {
            return Task.FromResult(usd * 18.5m);
        }
    }
}