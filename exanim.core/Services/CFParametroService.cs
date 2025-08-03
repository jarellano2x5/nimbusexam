using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class CFParametroService(IRepository<CFParametro> repository, IMapper mapper) : ICFParametroService
{
    private readonly IRepository<CFParametro> _repo = repository;
    private readonly IMapper _map = mapper;
    
    public async Task<CFParametroDTO> AddAsync(CFParametroDTO dto)
    {
        try
        {
            CFParametro? ck = await _repo.GetAsync(p => p.Clave == dto.Clave);
            if (ck != null) throw new Exception("Record already exists");
            CFParametro mod = _map.Map<CFParametro>(dto);
            mod.ParametroId = Guid.NewGuid();
            await _repo.InsertAsync(mod);
            return dto with { ParametroId = mod.ParametroId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFParametroDTO> AttachAsync(Guid id, CFParametroDTO dto)
    {
        try
        {
            CFParametro? ck = await _repo.GetAsync(p => p.Clave == dto.Clave && p.ParametroId != id);
            if (ck != null) throw new Exception("Record already exists");
            CFParametro? mod = await _repo.GetAsync(id);
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
            CFParametro? mod = await _repo.GetAsync(id);
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
            IEnumerable<CFParametro> ls = await _repo.SearchAsync(u => 1 == 1);
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFParametroDTO> PickAsync(Guid id)
    {
        try
        {
            CFParametro? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            return _map.Map<CFParametroDTO>(mod);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
