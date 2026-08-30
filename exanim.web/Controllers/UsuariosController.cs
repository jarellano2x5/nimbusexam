using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController(ICFUsuarioService service) : ControllerBase
{
    private readonly ICFUsuarioService _logic = service;

    [HttpGet("[action]/{idagencia}")]
    public async Task<IEnumerable<CFSocioDTO>> GetSocios(Guid idagencia)
    {
        return await _logic.SociosAsync(idagencia);
    }
}
