using GLMS.API.Interfaces;
using GLMS.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GLMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _service;

        public ContractsController(IContractService service)
        {
            _service = service;
        }

     
        // GET ALL
    
        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? status,
            DateTime? startDate,
            DateTime? endDate)
        {
            return Ok(await _service.GetContractsAsync(status, startDate, endDate));
        }

       
        // GET BY ID
    
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contract = await _service.GetByIdAsync(id);

            if (contract == null)
                return NotFound();

            return Ok(contract);
        }

      
        // CREATE 
      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContractDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }

       
        // UPDATE 
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContractDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        
        // DELETE
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

       
        // STATUS UPDATE
    
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            await _service.UpdateStatusAsync(id, status);
            return NoContent();
        }

       
        // FILE UPLOAD 
       
        [HttpPost("{id}/upload")]
        public async Task<IActionResult> Upload(int id, IFormFile file)
        {
            await _service.UploadAgreementAsync(id, file);
            return Ok();
        }

      
        // FILE DOWNLOAD
     
        [HttpGet("{id}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var path = await _service.DownloadAgreementAsync(id);

            var fileName = Path.GetFileName(path);

            return PhysicalFile(path, "application/pdf", fileName);
        }
    }
}