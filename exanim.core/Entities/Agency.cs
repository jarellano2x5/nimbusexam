namespace exanim.core.Entities;

public class Agency : Entity
{
    public Guid AgencyId { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public Location Place { get; set; } = null!;
    public bool IsActive { get; set; }
}
