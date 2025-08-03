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

    [HttpGet]
    public async Task<IEnumerable<CFUsuarioDTO>> Get()
    {
        return await _logic.AllAsync();
    }
}
