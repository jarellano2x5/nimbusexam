using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFAgencia : Entity
{
    public Guid AgenciaId { get; set; }
    public string RFC { get; set; } = string.Empty;
    public string RazonSocial { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public CFTipoEnum Tipo { get; set; }
    public CFPlanEnum PlanEnum { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
}
