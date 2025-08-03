using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AfiliadosController(ICFAfiliadoService service) : ControllerBase
{
    private readonly ICFAfiliadoService _logic = service;

    [HttpPost("[action]")]
    public async Task<ActionResult<CFSignedDTO>> Login([FromBody] CFLoginDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.LoginAsync(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CFSignedDTO>> Post([FromBody] CFAfiliadoDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await _logic.RegisterAsync(dto);
    }
}
