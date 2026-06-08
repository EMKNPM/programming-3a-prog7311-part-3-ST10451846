using GLMS.API.Interfaces;
using GLMS.API.Models;
using GLMS.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GLMS.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _service.GetByIdAsync(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            await _service.CreateAsync(client);
            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            await _service.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
