namespace exanim.core.Entities;

public class OPAutoriza : Entity
{
    public Guid AutorizaId { get; set; }
    public bool Autorizado { get; set; }
    public string Comentarion { get; set; } = string.Empty;
    public Guid AvanceId { get; set; }
    public Guid AccionId { get; set; }
}
