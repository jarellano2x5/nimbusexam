using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfiguracionesController(ICFConfiguraService service) : ControllerBase
{
    private readonly ICFConfiguraService _logic = service;

    [HttpGet("{ida}")]
    public async Task<IEnumerable<Item>> Get(Guid ida)
    {
        return await _logic.ItemsAsync(ida);
    }

    [HttpPost]
    public async Task<ActionResult<CFConfiguraDTO>> Post([FromBody] CFConfiguraDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(dto);
    }
}
