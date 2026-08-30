using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParametrosController(ICFParametroService service) : ControllerBase
{
    private readonly ICFParametroService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get()
    {
        return await _logic.ItemsAsync("");
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] IEnumerable<CFParametroDTO> dtos)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddsAsync(null, dtos);
    }

    [HttpDelete("{ids}")]
    public async Task<ActionResult<bool>> Delete(Guid[] ids)
    {
        return await _logic.DownsAsync(ids);
    }
}
