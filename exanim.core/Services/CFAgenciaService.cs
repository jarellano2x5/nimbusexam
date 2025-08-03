using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class CFAgenciaService(IRepository<CFAgencia> repository, IMapper mapper) : ICFAgenciaService
{
    private readonly IRepository<CFAgencia> _repo = repository;
    private readonly IMapper _map = mapper;
    
    public async Task<CFAgenciaDTO> AddAsync(CFAgenciaDTO dto)
    {
        try
        {
            CFAgencia? ck = await _repo.GetAsync(a => a.RFC == dto.RFC);
            if (ck != null) throw new Exception("Record already exists");
            CFAgencia mod = _map.Map<CFAgencia>(dto);
            mod.AgenciaId = Guid.NewGuid();
            await _repo.InsertAsync(mod);
            return dto with { AgenciaId = mod.AgenciaId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFAgenciaDTO> AttachAsync(Guid id, CFAgenciaDTO dto)
    {
        try
        {
            CFAgencia? ck = await _repo.GetAsync(a => a.RFC == dto.RFC && a.AgenciaId == id);
            if (ck != null) throw new Exception("Record already exists");
            CFAgencia? mod = await _repo.GetAsync(id);
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
            CFAgencia? mod = await _repo.GetAsync(id);
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
            IEnumerable<CFAgencia> ls = await _repo.SearchAsync(a => 1 == 1);
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFAgenciaDTO> PickAsync(Guid id)
    {
        try
        {
            CFAgencia? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            return _map.Map<CFAgenciaDTO>(mod);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
