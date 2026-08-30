using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarcasController(IBrandService service) : ControllerBase
{
    private readonly IBrandService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(string criterio = "")
    {
        return await _logic.ItemsAsync(criterio);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] IEnumerable<BrandDTO> dtos, CancellationToken kt = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddsAsync(null, dtos, kt);
    }

    [HttpDelete("{ids}")]
    public async Task<ActionResult<bool>> Delete(Guid[] ids, CancellationToken kt = default)
    {
        return await _logic.DownsAsync(ids, kt);
    }
}
