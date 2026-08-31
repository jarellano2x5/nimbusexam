using exanim.core.DTOs;

namespace exanim.core.Entities;

public partial class VECotizacion : Entity
{
    public DateTime Fecha { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Vehiculo { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateOnly Vigencia { get; set; }
    public bool Activo { get; set; }
    public bool Aceptada { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid AgenciaId { get; set; }
    public Guid? OrdenId { get; set; }
    public Guid? ClienteId { get; set; }

    public virtual ICollection<VELinea> Lineas { get; set; } = [];
}

public static class CotizacionExtensions
{
    extension(VECotizacion m)
    {
        
    }

    extension(VECotizacionDTO d)
    {
        public VECotizacion ToModel(Guid idAgencia) => new()
        {
            Id = Guid.NewGuid(),
            Fecha = DateTime.Now,
            Clave = d.Clave,
            Vehiculo = d.Vehiculo,
            Monto = d.Monto,
            Vigencia = d.Vigencia,
            Activo = d.Activo,
            Aceptada = d.Aceptada,
            UsuarioId = d.Usuario.Id,
            AgenciaId = idAgencia,
            OrdenId = d.Orden?.Id,
            ClienteId = d.Cliente?.Id
        };
    }
}