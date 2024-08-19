using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public class UserDTO
{
    public Guid UserId { get; set; }
    [Length(5, 20)]
    public string Nick { get; set; } = string.Empty;
    [Length(8, 30)]
    public string Password { get; set; } = string.Empty;
    [Length(10, 150)]
    public string Mail { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
