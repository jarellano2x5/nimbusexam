namespace exanim.core.Entities;

public class WorkOrder : Entity
{
    public Guid OrderId { get; set; }
    public Guid VehicleId { get; set; }
    public Guid AgencyId { get; set; }
    public string Problem { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;
    public DateTime ProvidedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid StageId { get; set; }
}
