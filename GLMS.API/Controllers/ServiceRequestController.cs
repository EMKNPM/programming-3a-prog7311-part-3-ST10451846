using GLMS.API.Interfaces;
using GLMS.API.Models;
using GLMS.Models;
using GLMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/ServiceRequests")]

public class ServiceRequestController : ControllerBase
{
    private readonly IServiceRequestService _service;

    public ServiceRequestController(IServiceRequestService service)
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
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ServiceRequestDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ServiceRequestDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("convert/{usd}")]
    public async Task<IActionResult> Convert(decimal usd)
    {
        var result = await _service.ConvertUsdToZar(usd);
        return Ok(result);
    }
}