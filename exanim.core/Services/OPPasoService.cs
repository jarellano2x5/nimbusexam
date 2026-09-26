using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class OPPasoService(IUnitOfWork unitOfWork) : IOPPasoService
{
    private readonly IUnitOfWork _unit = unitOfWork;
    public Task<int> AddsAsync(AuthMe me, IEnumerable<OPPasoDTO> dtos, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownsAsync(Guid[] ids, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Item>> ItemsAsync(AuthMe me, string srch, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}