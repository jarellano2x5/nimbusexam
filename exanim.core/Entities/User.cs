using System;

namespace exanim.core.Entities;

public class User : Entity
{
    public Guid UserId { get; set; }
    public string Nick { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
