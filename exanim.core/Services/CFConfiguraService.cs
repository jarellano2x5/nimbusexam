using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class CFConfiguraService(IRepositoryAlt<CFConfigura> repository, IMapper mapper) : ICFConfiguraService
{
    private readonly IRepositoryAlt<CFConfigura> _repo = repository;
    private readonly IMapper _map = mapper;

    public async Task<CFConfiguraDTO> AddAsync(CFConfiguraDTO dto)
    {
        try
        {
            CFConfigura? ck = await _repo.GetAsync(dto.AgenciaId, dto.ParametroId);
            if (ck != null) throw new Exception("Record already exists");
            CFConfigura mod = dto.Adapt<CFConfigura>();
            await _repo.InsertAsync(mod);
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<CFConfiguraDTO> AttachAsync(Guid id, CFConfiguraDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DownAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Item>> ItemsAsync(Guid idAgencia)
    {
        try
        {
            IEnumerable<CFConfigura> ls = await _repo.SearchAsync(d => d.AgenciaId == idAgencia);
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<CFConfiguraDTO> PickAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
