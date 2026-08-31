using exanim.core.DTOs;
using exanim.core.Interfaces;
using exanim.web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfiguracionesController(ICFConfiguraService service) : ControllerBase
{
    private readonly ICFConfiguraService _logic = service;

    [HttpGet("{ida}")]
    public async Task<IEnumerable<Item>> Get(Guid ida, CancellationToken kt)
    {
        return await _logic.ItemsAsync(ida, kt);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] IEnumerable<CFConfiguraDTO> dtos, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddsAsync(User.ToAuth(), dtos, kt);
    }
}
