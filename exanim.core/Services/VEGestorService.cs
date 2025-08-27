using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class VEGestorService(IRepository<VEGestor> repository, IMapper mapper) : IVEGestorService
{
    private readonly IRepository<VEGestor> _repo = repository;
    private readonly IMapper _map = mapper;

    public async Task<VEGestorDTO> AddAsync(VEGestorDTO dto)
    {
        try
        {
            VEGestor mod = _map.Map<VEGestor>(dto);
            mod.GestorId = Guid.NewGuid();
            await _repo.InsertAsync(mod);
            return dto with { GestorId = mod.GestorId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEGestorDTO> AttachAsync(Guid id, VEGestorDTO dto)
    {
        try
        {
            VEGestor? mod = await _repo.GetAsync(id);
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
            VEGestor? mod = await _repo.GetAsync(id);
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
            IEnumerable<VEGestor> ls = await _repo.SearchAsync(s => 1 == 1);
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEGestorDTO> PickAsync(Guid id)
    {
        try
        {
            VEGestor? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            return _map.Map<VEGestorDTO>(mod);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
