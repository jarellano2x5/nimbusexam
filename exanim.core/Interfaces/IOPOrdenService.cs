using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IOPOrdenService
{
    Task<OPOrdenDTO> AddAsync(Guid idUsuario, OPOrdenDTO dto, CancellationToken ct = default);
    Task<IEnumerable<OPOrdenMinDTO>> GetAllAsync(Guid idTaller, string criterio, int semana, CancellationToken ct = default);
    Task<OPOrdenDTO> GetAsync(Guid id, CancellationToken ct = default);
}
