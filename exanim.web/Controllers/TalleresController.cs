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

    [HttpGet]
    public async Task<IEnumerable<Item>> Get()
    {
        return await _logic.ItemsAsync("");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CFTallerDTO>> Get(Guid id)
    {
        return await _logic.PickAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<CFTallerDTO>> Post([FromBody] CFTallerDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CFTallerDTO>> Put(Guid id, [FromBody] CFTallerDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AttachAsync(id, dto);
    }
}
