using System;

namespace exanim.core.DTOs;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool Active { get; set; }
}
