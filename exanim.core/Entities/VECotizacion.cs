using exanim.core.DTOs;

namespace exanim.core.Entities;

public partial class VECotizacion : Entity
{
    public DateTime Fecha { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Vehiculo { get; set; } = string.Empty;
    public float Monto { get; set; }
    public DateOnly Vigencia { get; set; }
    public bool Activo { get; set; }
    public bool Aceptada { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid AgenciaId { get; set; }
    public Guid? OrdenId { get; set; }
    public Guid? ClienteId { get; set; }
    public Guid? UnidadId { get; set; }

    public virtual VEUnidad? Unidad { get; set; }
    public virtual ICollection<VELinea> Lineas { get; set; } = [];
}

public static class CotizacionExtensions
{
    extension(VECotizacion m)
    {
        public VECotizacion ToExists(VECotizacionDTO d)
        {
            m.Clave = d.Clave;
            m.Vehiculo = d.Vehiculo;
            m.Monto = d.Monto;
            m.Vigencia = d.Vigencia;
            m.Activo = d.Activo;
            m.Aceptada = d.Aceptada;
            m.OrdenId = d.Orden?.Id;
            m.ClienteId = d.Cliente?.Id;
            return m;
        }

        public VECotizacionDTO ToDto() => new()
        {
            Id = m.Id,
            Fecha = m.Fecha,
            Clave = m.Clave,
            Vehiculo = m.Vehiculo,
            Monto = m.Monto,
            Vigencia = m.Vigencia,
            Activo = m.Activo,
            Aceptada = m.Aceptada,
            Usuario = new Item(m.UsuarioId, ""),
            Cliente = m.ClienteId == null ? null : new Item(m.ClienteId.Value, ""),
            Orden = m.OrdenId == null ? null : new Item(m.OrdenId.Value, "")
        };

        public VECotizacionMinDTO ToMin() => new()
        {
            Id = m.Id,
            Fecha = m.Fecha,
            Clave = m.Clave,
            Vehiculo = m.Vehiculo,
            Monto = m.Monto,
            Vigencia = m.Vigencia,
            Aceptada = m.Aceptada,
            Unidad = m.Unidad == null
            ? null
            : new Item(m.Unidad.Id, m.Unidad.Placa, $"{m.Unidad.Modelo} {m.Unidad.Anio}" ),
        };
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