using exanim.core.Entities;

namespace exanim.core.Storages;

public interface IUnitOfWork : IDisposable
{
    IRepository<Brand> Brands { get; }
    IRepository<CFAgencia> Agencias { get; }
    IRepository<CFConfigura> Configuras { get; }
    IRepository<CFOperador> Operadores { get; }
    IRepository<CFParametro> Parametros { get; }
    IRepository<CFPerfil> Perfiles { get; }
    IRepository<CFRol> Roles { get; }
    IRepository<CFSocio> Socios { get; }
    IRepository<CFTaller> Talleres { get; }
    IRepository<CFUsuario> Usuarios { get; }
    IRepository<OPAccion> Acciones { get; }
    IRepository<OPAutoriza> Autorizas { get; }
    IRepository<OPAvance> Avances { get; }
    IRepository<OPClase> Clases { get; }
    IRepository<OPEstado> Estados { get; }
    IRepository<OPInstalacion> Instalaciones { get; }
    IRepository<OPOrden> Ordenes { get; }
    IRepository<OPPaso> Pasos { get; }
    IRepository<OPPieza> Piezas { get; }
    IRepository<OPRemocion> Remociones { get; }
    IRepository<VECliente> Clientes { get; }
    IRepository<VECompania> Companias { get; }
    IRepository<VECotizacion> Cotizaciones { get; }
    IRepository<VELinea> Lineas { get; }
    IRepository<VEUnidad> Unidades { get; }
    
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}