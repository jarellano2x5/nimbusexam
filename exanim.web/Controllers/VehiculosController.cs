using exanim.core.DTOs;
using exanim.core.Interfaces;
using exanim.web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiculosController(IVEUnidadService service) : ControllerBase
{
    private readonly IVEUnidadService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(string criterio = "", CancellationToken kt = default)
    {
        return await _logic.ItemsAsync(User.ToAuth(), criterio, kt);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VEUnidadDTO>> Get(Guid id, CancellationToken kt)
    {
        return await _logic.PickAsync(id, kt);
    }

    [HttpPost]
    public async Task<ActionResult<VEUnidadDTO>> Post([FromBody] VEUnidadDTO dto, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(User.ToAuth(), dto, kt);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VEUnidadDTO>> Put(Guid id, [FromBody] VEUnidadDTO dto, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.FixAsync(User.ToAuth(), id, dto, kt);
    }
}
