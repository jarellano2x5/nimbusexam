using exanim.core.DTOs;

namespace exanim.core.Entities;

public class OPOrden : Entity
{
    public DateTime Fecha { get; set; }
    public string Problema { get; set; } = string.Empty;
    public string Condicion { get; set; } = string.Empty;
    public string? Correo { get; set; }
    public DateOnly? FechaEntrega { get; set; }
    public Guid UnidadId { get; set; }
    public Guid ClienteId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid TallerId { get; set; }
    public Guid EstadoId { get; set; }

    public virtual OPEstado Estado { get; set; } = null!;
    public virtual VEUnidad Unidad { get; set; } = null!;
}

public static class OrdenExtensions
{
    extension(OPOrden m)
    {
        public OPOrdenDTO ToDto() => new()
        {
            Id = m.Id,
            Fecha = m.Fecha,
            Problema = m.Problema,
            Condicion = m.Condicion,
            Correo = m.Correo,
            FechaEntrega = m.FechaEntrega,
            Unidad = new(m.UnidadId, m.Unidad.Placa, $"{m.Unidad.Modelo} {m.Unidad.Color}"),
            Cliente = new(m.ClienteId, ""),
            Taller = new(m.TallerId, ""),
            Estado = new(m.EstadoId, m.Estado.Nombre, m.Estado.Code)
        };

        public OPOrdenMinDTO ToMin() => new()
        {
            Id = m.Id,
            Fecha = m.Fecha,
            Correo = m.Correo,
            FechaEntrega = m.FechaEntrega,
            Unidad = new(m.Id, m.Unidad.Placa, $"{m.Unidad.Modelo} {m.Unidad.Color}"),
            Estado = new(m.Estado.Id, m.Estado.Nombre, m.Estado.Code)
        };
    }

    extension(OPOrdenDTO d)
    {
        public OPOrden ToModel(Guid idUser) => new()
        {
            Id = Guid.NewGuid(),
            Fecha = DateTime.Now,
            Problema = d.Problema,
            Condicion = d.Condicion,
            Correo = d.Correo,
            FechaEntrega = d.FechaEntrega,
            UnidadId = d.Unidad.Id,
            ClienteId = d.Cliente.Id,
            TallerId = d.Taller.Id,
            EstadoId = d.Estado.Id,
            UsuarioId = idUser
        };
    }
}