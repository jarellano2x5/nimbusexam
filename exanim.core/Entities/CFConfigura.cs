namespace exanim.core.Entities;

public class CFConfigura : EntityAlt
{
    public Guid AgenciaId { get; set; }
    public Guid ParametroId { get; set; }
    public int Valor { get; set; }
    public string Cadena { get; set; } = string.Empty;
}
