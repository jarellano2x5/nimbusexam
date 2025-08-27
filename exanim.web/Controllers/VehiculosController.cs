using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiculosController(IVEUnidadService service) : ControllerBase
{
    private readonly IVEUnidadService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(string criterio = "")
    {
        return await _logic.ItemsAsync(criterio);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VEUnidadDTO>> Get(Guid id)
    {
        return await _logic.PickAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<VEUnidadDTO>> Post([FromBody] VEUnidadDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VEUnidadDTO>> Put(Guid id, [FromBody] VEUnidadDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AttachAsync(id, dto);
    }
}
