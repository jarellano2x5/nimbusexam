using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record class CFConfiguraDTO
{
    [Required]
    public Guid AgenciaId { get; set; }
    [Required]
    public Guid ParametroId { get; set; }
    [Required]
    public int Valor { get; set; }
    [Required]
    [MaxLength(300)]
    public string Cadena { get; set; } = string.Empty;
}
