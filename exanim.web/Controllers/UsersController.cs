using exanim.core.DTOs;
using exanim.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exanim.web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _logic;

    public UsersController(IUserService service)
    {
        _logic = service;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDTO>> Get()
    {
        return await _logic.AllAsync();
    }
}
