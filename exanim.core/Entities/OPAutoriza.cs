namespace exanim.core.Entities;

public class OPAutoriza : Entity
{
    public bool Autorizado { get; set; }
    public string Comentario { get; set; } = string.Empty;
    public Guid AvanceId { get; set; }
    public Guid AccionId { get; set; }
}
