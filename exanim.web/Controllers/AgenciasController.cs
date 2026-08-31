using exanim.core.DTOs;
using exanim.core.Interfaces;
using exanim.web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgenciasController(ICFAgenciaService service) : ControllerBase
{
    private readonly ICFAgenciaService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(CancellationToken kt)
    {
        AuthMe me = User.ToAuth();
        return await _logic.ItemsAsync(me, "", kt);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CFAgenciaDTO>> Get(Guid id, CancellationToken kt)
    {
        return await _logic.PickAsync(id, kt);
    }

    [HttpPost]
    public async Task<ActionResult<CFAgenciaDTO>> Post([FromBody] CFAgenciaDTO dto, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        AuthMe me = User.ToAuth();
        return await _logic.AddAsync(me, dto, kt);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CFAgenciaDTO>> Put(Guid id, [FromBody] CFAgenciaDTO dto, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        AuthMe me = User.ToAuth();
        return await _logic.FixAsync(me, id, dto, kt);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id, CancellationToken kt)
    {
        return await _logic.DownAsync(id, kt);
    }
}
