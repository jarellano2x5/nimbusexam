using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PerfilesController(ICFPerfilService service) : ControllerBase
{
    private readonly ICFPerfilService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get()
    {
        return await _logic.ItemsAsync("");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CFPerfilDTO>> Get(Guid id)
    {
        return await _logic.PickAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<CFPerfilDTO>> Post([FromBody] CFPerfilDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CFPerfilDTO>> Put(Guid id, [FromBody] CFPerfilDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AttachAsync(id, dto);
    }
}
