using exanim.core.Enums;

namespace exanim.core.Entities;

public class OPPaso : Entity
{
    public Guid FlowId { get; set; }
    public OPTipoEnum Tipo { get; set; }
    public bool Activo { get; set; }
    public Guid PrevioId { get; set; }
    public Guid AvanzaId { get; set; }
}
