namespace exanim.core.DTOs;

public class OPPasoDTO
{
    public Guid? Id { get; set; }
    public Item Etapa { get; set; } = null!;
    public Item Previo { get; set; } = null!;
    public Item Siguiente { get; set; } = null!;
}
