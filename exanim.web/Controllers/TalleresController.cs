using exanim.core.DTOs;
using exanim.core.Interfaces;
using exanim.web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TalleresController(ICFTallerService service) : ControllerBase
{
    private readonly ICFTallerService _logic = service;

    [HttpGet("[action]/{idagencia}")]
    public async Task<IEnumerable<Item>> GetItems(Guid idagencia, CancellationToken kt)
    {
        return await _logic.ItemsAsync(User.ToAuth(), "", kt);
    }

    [HttpPost("{idagencia}")]
    public async Task<ActionResult<int>> Post(Guid idagencia, [FromBody] IEnumerable<CFTallerDTO> dtos, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddsAsync(User.ToAuth(), dtos, kt);
    }

    [HttpDelete("{ids}")]
    public async Task<ActionResult<bool>> Put(Guid[] ids, CancellationToken kt)
    {
        return await _logic.DownsAsync(ids, kt);
    }
}
