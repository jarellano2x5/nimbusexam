using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;

namespace exanim.core.Services;

public class CFAgenciaService : ICFAgenciaService
{
    private readonly IRepository<CFAgencia> _repo;

    public CFAgenciaService(IRepository<CFAgencia> repository)
    {
        _repo = repository;
    }
    
    public Task<CFAgenciaDTO> AddAsync(CFAgenciaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<CFAgenciaDTO> AttachAsync(Guid id, CFAgenciaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Item>> ItemsAsync(string srch)
    {
        throw new NotImplementedException();
    }

    public Task<CFAgenciaDTO> PickAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
