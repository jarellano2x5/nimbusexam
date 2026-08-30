using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TalleresController(ICFTallerService service) : ControllerBase
{
    private readonly ICFTallerService _logic = service;

    [HttpGet("[action]/{idagencia}")]
    public async Task<IEnumerable<Item>> GetItems(Guid idagencia, CancellationToken kt = default)
    {
        return await _logic.ItemsAsync(idagencia, "", kt);
    }

    [HttpPost("{idagencia}")]
    public async Task<ActionResult<int>> Post(Guid idagencia, [FromBody] IEnumerable<CFTallerDTO> dtos, CancellationToken kt = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddsAsync(idagencia, dtos, kt);
    }

    [HttpDelete("{ids}")]
    public async Task<ActionResult<bool>> Put(Guid[] ids, CancellationToken kt = default)
    {
        return await _logic.DownsAsync(ids, kt);
    }
}
