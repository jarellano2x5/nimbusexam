using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class VECotizacionService(IUnitOfWork unitOfWork) : IVECotizacionService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public Task<VECotizacionDTO> AddAsync(AuthMe me, VECotizacionDTO dto, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<VECotizacionDTO> FixAsync(AuthMe me, Guid id, VECotizacionDTO dto, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<DPage<VECotizacionMinDTO>> PageAsync(AuthMe me, DateTime date, Guid stage, int size = 15, int page = 0, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<VECotizacionDTO> PickAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
