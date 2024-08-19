using exanim.core.Enums;

namespace exanim.core.Entities;

public class Stage : Entity
{
    public Guid StageId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public PhaseEnum Phase { get; set; }
}
