namespace exanim.core.Entities;

public class Brand : Entity
{
    public Guid BrandId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Activo { get; set; }
}
