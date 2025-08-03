using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class CFPerfilService(
    IRepository<CFPerfil> repository, IMapper mapper
) : ICFPerfilService
{
    private readonly IRepository<CFPerfil> _repo = repository;
    private readonly IMapper _map = mapper;
    public async Task<CFPerfilDTO> AddAsync(CFPerfilDTO dto)
    {
        try
        {
            CFPerfil mod = _map.Map<CFPerfil>(dto);
            mod.PerfilId = Guid.NewGuid();
            await _repo.InsertAsync(mod);
            return dto with { PerfilId = mod.PerfilId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFPerfilDTO> AttachAsync(Guid id, CFPerfilDTO dto)
    {
        try
        {
            CFPerfil? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Not found record");
            dto.Adapt(mod);
            await _repo.UpdateAsync(mod);
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<bool> DownAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Item>> ItemsAsync(string srch)
    {
        try
        {
            IEnumerable<CFPerfil> ls = await _repo.SearchAsync(s => 1 == 1, false, false);
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFPerfilDTO> PickAsync(Guid id)
    {
        try
        {
            CFPerfil? mod = await _repo.GetAsync(id);
            if (mod is null) throw new Exception("Record not found");
            return _map.Map<CFPerfilDTO>(mod);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
