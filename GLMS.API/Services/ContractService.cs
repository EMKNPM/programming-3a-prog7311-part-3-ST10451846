using GLMS.API.Data;
using GLMS.API.Interfaces;
using GLMS.API.Models;
using GLMS.Models;
using Microsoft.EntityFrameworkCore;

namespace GLMS.API.Services
{
    public class ContractService : IContractService
    {
        private readonly GLMSDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ContractService(GLMSDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // ✅ GET ALL (DTO)
        public async Task<List<ContractDto>> GetContractsAsync(
            string? status,
            DateTime? startDate,
            DateTime? endDate)
        {
            var query = _context.Contracts
                .Include(c => c.Client)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(c => c.Status == status);

            if (startDate.HasValue)
                query = query.Where(c => c.StartDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(c => c.EndDate <= endDate.Value);

            return await query
                .Select(c => new ContractDto
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    ClientName = c.Client.Name,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Status = c.Status,
                    ServiceLevel = c.ServiceLevel,
                    AgreementFilePath = c.AgreementFilePath
                })
                .ToListAsync();
        }

        // ✅ GET BY ID (DTO)
        public async Task<ContractDto?> GetByIdAsync(int id)
        {
            return await _context.Contracts
                .Include(c => c.Client)
                .Where(c => c.Id == id)
                .Select(c => new ContractDto
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    ClientName = c.Client.Name,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Status = c.Status,
                    ServiceLevel = c.ServiceLevel,
                    AgreementFilePath = c.AgreementFilePath
                })
                .FirstOrDefaultAsync();
        }

        // ✅ CREATE (DTO → Entity → DTO)
        public async Task<ContractDto> CreateAsync(ContractDto dto)
        {
            var contract = new Contract
            {
                ClientId = dto.ClientId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = dto.Status,
                ServiceLevel = dto.ServiceLevel,
                AgreementFilePath = dto.AgreementFilePath
            };

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            dto.Id = contract.Id;
            return dto;
        }

        // ✅ UPDATE (DTO)
        public async Task UpdateAsync(int id, ContractDto dto)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null) return;

            contract.StartDate = dto.StartDate;
            contract.EndDate = dto.EndDate;
            contract.Status = dto.Status;
            contract.ServiceLevel = dto.ServiceLevel;

            await _context.SaveChangesAsync();
        }

        // ✅ DELETE
        public async Task DeleteAsync(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null) return;

            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
        }

        // ✅ STATUS UPDATE
        public async Task UpdateStatusAsync(int id, string status)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null) return;

            contract.Status = status;
            await _context.SaveChangesAsync();
        }

        // ✅ FILE UPLOAD (correct)
        public async Task UploadAgreementAsync(int id, IFormFile file)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract == null)
                throw new Exception("Contract not found");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            contract.AgreementFilePath = "/uploads/" + fileName;
            await _context.SaveChangesAsync();
        }

        // ✅ DOWNLOAD
        public async Task<string> DownloadAgreementAsync(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract == null || contract.AgreementFilePath == null)
                throw new Exception("File not found");

            return Path.Combine(
                _env.WebRootPath,
                "uploads",
                contract.AgreementFilePath);
        }
    }
}