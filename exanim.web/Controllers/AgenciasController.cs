using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgenciasController(ICFAgenciaService service) : ControllerBase
{
    private readonly ICFAgenciaService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get()
    {
        return await _logic.ItemsAsync("");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CFAgenciaDTO>> Get(Guid id)
    {
        return await _logic.PickAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<CFAgenciaDTO>> Post([FromBody] CFAgenciaDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CFAgenciaDTO>> Put(Guid id, [FromBody] CFAgenciaDTO dto)
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
