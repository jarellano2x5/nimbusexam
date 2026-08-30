using exanim.core.Entities;
using exanim.core.Storages;
using exanim.root.Data;

namespace exanim.root.Repositories;

public class UnitOfWork(AppCtx context) : IUnitOfWork
{
    private readonly AppCtx _ctx = context;
    
    private IRepository<Brand>? _brands;
    private IRepository<CFAgencia>? _agencias;
    private IRepository<CFConfigura>? _configuras;
    private IRepository<CFOperador>? _operadores;
    private IRepository<CFParametro>? _parametros;
    private IRepository<CFPerfil>? _perfiles;
    private IRepository<CFRol>? _roles;
    private IRepository<CFSocio>? _socios;
    private IRepository<CFTaller>? _talleres;
    private IRepository<CFUsuario>? _usuarios;
    private IRepository<OPAccion>? _acciones;
    private IRepository<OPAutoriza>? _autorizas;
    private IRepository<OPAvance>? _avances;
    private IRepository<OPClase>? _clases;
    private IRepository<OPEstado>? _estados;
    private IRepository<OPInstalacion>? _instalaciones;
    private IRepository<OPOrden>? _ordenes;
    private IRepository<OPPaso>? _pasos;
    private IRepository<OPPieza>? _piezas;
    private IRepository<OPRemocion>? _remociones;
    private IRepository<VECliente>? _clientes;
    private IRepository<VECompania>? _companias;
    private IRepository<VECotizacion>? _cotizaciones;
    private IRepository<VELinea>? _lineas;
    private IRepository<VEUnidad>? _unidades;
    
    public IRepository<Brand> Brands  => _brands ??= new Repository<Brand>(_ctx);
    public IRepository<CFAgencia> Agencias => _agencias ??= new Repository<CFAgencia>(_ctx);
    public IRepository<CFConfigura> Configuras => _configuras ??= new Repository<CFConfigura>(_ctx);
    public IRepository<CFOperador> Operadores => _operadores ??= new Repository<CFOperador>(_ctx);
    public IRepository<CFParametro> Parametros => _parametros ??= new Repository<CFParametro>(_ctx);
    public IRepository<CFPerfil> Perfiles => _perfiles ??= new Repository<CFPerfil>(_ctx);
    public IRepository<CFRol> Roles => _roles ??= new Repository<CFRol>(_ctx);
    public IRepository<CFSocio> Socios => _socios ??= new Repository<CFSocio>(_ctx);
    public IRepository<CFTaller> Talleres => _talleres ??= new Repository<CFTaller>(_ctx);
    public IRepository<CFUsuario> Usuarios => _usuarios ??= new Repository<CFUsuario>(_ctx);
    public IRepository<OPAccion> Acciones => _acciones ??= new Repository<OPAccion>(_ctx);
    public IRepository<OPAutoriza> Autorizas => _autorizas ??= new Repository<OPAutoriza>(_ctx);
    public IRepository<OPAvance> Avances => _avances ??= new Repository<OPAvance>(_ctx);
    public IRepository<OPClase> Clases => _clases ??= new Repository<OPClase>(_ctx);
    public IRepository<OPEstado> Estados => _estados ??= new Repository<OPEstado>(_ctx);
    public IRepository<OPInstalacion> Instalaciones => _instalaciones ??= new Repository<OPInstalacion>(_ctx);
    public IRepository<OPOrden> Ordenes => _ordenes ??= new Repository<OPOrden>(_ctx);
    public IRepository<OPPaso> Pasos => _pasos ??= new Repository<OPPaso>(_ctx);
    public IRepository<OPPieza> Piezas => _piezas ??= new Repository<OPPieza>(_ctx);
    public IRepository<OPRemocion> Remociones => _remociones ??= new Repository<OPRemocion>(_ctx);
    public IRepository<VECliente> Clientes => _clientes ??= new Repository<VECliente>(_ctx);
    public IRepository<VECompania> Companias => _companias ??= new Repository<VECompania>(_ctx);
    public IRepository<VECotizacion> Cotizaciones => _cotizaciones ??= new Repository<VECotizacion>(_ctx);
    public IRepository<VELinea> Lineas => _lineas ??= new Repository<VELinea>(_ctx);
    public IRepository<VEUnidad> Unidades => _unidades ??= new Repository<VEUnidad>(_ctx);

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _ctx.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()  => _ctx.Dispose();
}