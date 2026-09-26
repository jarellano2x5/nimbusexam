using exanim.core.DTOs;

namespace exanim.core.Entities;

public class VELinea : Entity
{
    public string Clave { get; set; } = string.Empty;
    public string Unidad { get; set; } = string.Empty;
    public string Concepto { get; set; } = string.Empty;
    public float Cantidad { get; set; }
    public float Precio { get; set; }
    public float Importe => Cantidad * Precio;
    public Guid CotizacionId { get; set; }
}

public static class LineaExtensions
{
    extension(VELinea m)
    {
        public VELinea ToExists(VELineaDTO d)
        {
            m.Clave = d.Clave;
            m.Unidad = d.Unidad;
            m.Concepto = d.Concepto;
            m.Cantidad = d.Cantidad;
            m.Precio = d.Precio;
            return m;
        }
    }

    extension(VELineaDTO d)
    {
        public VELinea ToModel(Guid idCotiza) => new()
        {
            Id = Guid.NewGuid(),
            Clave = d.Clave,
            Unidad = d.Unidad,
            Concepto = d.Concepto,
            Cantidad = d.Cantidad,
            Precio = d.Precio,
            CotizacionId = idCotiza
        };
    }
}