using exanim.core.DTOs;
using exanim.core.Interfaces;
using exanim.web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarcasController(IBrandService service) : ControllerBase
{
    private readonly IBrandService _logic = service;

    [HttpGet]
    public async Task<IEnumerable<Item>> Get(CancellationToken kt, string criterio = "")
    {
        AuthMe me = User.ToAuth();
        return await _logic.ItemsAsync(me, criterio, kt);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] IEnumerable<BrandDTO> dtos, CancellationToken kt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.AddsAsync(User.ToAuth(), dtos, kt);
    }

    [HttpDelete("{ids}")]
    public async Task<ActionResult<bool>> Delete(Guid[] ids, CancellationToken kt)
    {
        return await _logic.DownsAsync(ids, kt);
    }
}
