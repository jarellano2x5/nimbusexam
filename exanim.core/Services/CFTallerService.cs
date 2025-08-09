using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class CFTallerService(IRepository<CFTaller> repository, IMapper mapper) : ICFTallerService
{
    private readonly IRepository<CFTaller> _repo = repository;
    private readonly IMapper _map = mapper;

    public async Task<CFTallerDTO> AddAsync(CFTallerDTO dto)
    {
        try
        {
            CFTaller? ck = await _repo.GetAsync(a => a.Codigo == dto.Codigo);
            if (ck != null) throw new Exception("Record already exists");
            CFTaller mod = _map.Map<CFTaller>(dto);
            mod.TallerId = Guid.NewGuid();
            await _repo.InsertAsync(mod);
            return dto with { TallerId = mod.TallerId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFTallerDTO> AttachAsync(Guid id, CFTallerDTO dto)
    {
        try
        {
            CFTaller? ck = await _repo.GetAsync(t => t.Codigo == dto.Codigo && t.TallerId != id);
            if (ck != null) throw new Exception("Record already exists");
            CFTaller? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            mod.Adapt(dto);
            await _repo.UpdateAsync(mod);
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DownAsync(Guid id)
    {
        try
        {
            CFTaller? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            if (!mod.Activo) return false;
            mod.Activo = false;
            await _repo.UpdateAsync(mod);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Item>> ItemsAsync(string srch)
    {
        try
        {
            IEnumerable<CFTaller> ls = await _repo.SearchAsync(t => 1 == 1);
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFTallerDTO> PickAsync(Guid id)
    {
        try
        {
            CFTaller? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            return _map.Map<CFTallerDTO>(mod);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
