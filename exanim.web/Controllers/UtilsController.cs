using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UtilsController(IUtilService service) : ControllerBase
{
    private readonly IUtilService _logic = service;

    [HttpGet("[action]")]
    public IEnumerable<Option> GetPerfil()
    {
        return _logic.GetPerfil();
    }

}
