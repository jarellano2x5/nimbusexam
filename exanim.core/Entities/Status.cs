using exanim.core.Enums;

namespace exanim.core.Entities;

public class Status : Entity
{
    public Guid StatusId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public StateEnum Kind { get; set; }
}
