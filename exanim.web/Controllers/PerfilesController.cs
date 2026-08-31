using exanim.core.DTOs;
using exanim.core.Interfaces;
using exanim.web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PerfilesController(ICFPerfilService service) : ControllerBase
{
    private readonly ICFPerfilService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(CancellationToken kt)
    {
        return await _logic.ItemsAsync(User.ToAuth(), "", kt);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CFPerfilDTO>> Get(Guid id, CancellationToken kt)
    {
        return await _logic.PickAsync(id, kt);
    }

    [HttpPost]
    public async Task<ActionResult<CFPerfilDTO>> Post([FromBody] CFPerfilDTO dto, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(User.ToAuth(), dto, kt);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id, CancellationToken kt)
    {
        return await _logic.DownAsync(id, kt);
    }
}
