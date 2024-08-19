namespace exanim.core.Entities;

public class Vehicle : Entity
{
    public Guid VehicleId { get; set; }
    public string Plate { get; set; } = string.Empty;
    public short Year { get; set; }
    public DateTime EnlistAt { get; set; }
    public Guid BrandId { get; set; }
    public Guid StatusId { get; set; }
}
