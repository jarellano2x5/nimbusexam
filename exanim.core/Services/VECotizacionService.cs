using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Helpers;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class VECotizacionService(IUnitOfWork unitOfWork, IAuthHelper authHelper) : IVECotizacionService
{
    private readonly IUnitOfWork _unit = unitOfWork;
    private readonly IAuthHelper _auth = authHelper;

    public Task<VECotizacionDTO> AddAsync(VECotizacionDTO dto, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<VECotizacionDTO> FixAsync(Guid id, VECotizacionDTO dto, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<DPage<VECotizacionMinDTO>> PageAsync(DateTime date, Guid stage, int size = 15, int page = 0, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<VECotizacionDTO> PickAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
