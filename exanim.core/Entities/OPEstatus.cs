using exanim.core.Enums;

namespace exanim.core.Entities;

public class OPEstatus : Entity
{
    public Guid EstatusId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public OPFaseEnum Fase { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid AgenciaId { get; set; }
}
