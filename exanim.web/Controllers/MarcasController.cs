using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarcasController(IBrandService service) : ControllerBase
{
    private readonly IBrandService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(string criterio = "")
    {
        return await _logic.ItemsAsync(criterio);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BrandDTO>> Get(Guid id)
    {
        return await _logic.PickAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<BrandDTO>> Post([FromBody] BrandDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BrandDTO>> Put(Guid id, [FromBody] BrandDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AttachAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        return await _logic.DownAsync(id);
    }
}
