using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class VEClienteService(IRepository<VECliente> repository, IMapper mapper) : IVEClienteService
{
    private readonly IRepository<VECliente> _repo = repository;
    private readonly IMapper _map = mapper;

    public async Task<VEClienteDTO> AddAsync(VEClienteDTO dto)
    {
        try
        {
            VECliente mod = _map.Map<VECliente>(dto);
            mod.Id = Guid.NewGuid();
            await _repo.InsertAsync(mod);
            return dto with { Id = mod.Id };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEClienteDTO> AttachAsync(Guid id, VEClienteDTO dto)
    {
        try
        {
            VECliente? mod = await _repo.GetAsync(id);
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
            VECliente? mod = await _repo.GetAsync(id);
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
            IEnumerable<VECliente> ls = await _repo.SearchAsync(s => 1 == 1);
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEClienteDTO> PickAsync(Guid id)
    {
        try
        {
            VECliente? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            return _map.Map<VEClienteDTO>(mod);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
