namespace exanim.core.Entities;

public class Daybook : Entity
{
    public Guid DaybookId { get; set; }
    public string Annotation { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public Guid StageId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
}
