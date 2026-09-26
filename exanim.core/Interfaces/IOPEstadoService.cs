using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IOPEstadoService : IBulk<OPEstadoDTO>, ICatalog
{
    Task<bool> Configure(AuthMe me, CancellationToken ct = default);
}
