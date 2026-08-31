using exanim.core.DTOs;
using exanim.core.Interfaces;
using exanim.web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParametrosController(ICFParametroService service) : ControllerBase
{
    private readonly ICFParametroService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(CancellationToken kt)
    {
        AuthMe me = User.ToAuth();
        return await _logic.ItemsAsync(me, "", kt);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] IEnumerable<CFParametroDTO> dtos, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        AuthMe me = User.ToAuth();
        return await _logic.AddsAsync(me, dtos, kt);
    }

    [HttpDelete("{ids}")]
    public async Task<ActionResult<bool>> Delete(Guid[] ids, CancellationToken kt)
    {
        return await _logic.DownsAsync(ids, kt);
    }
}
