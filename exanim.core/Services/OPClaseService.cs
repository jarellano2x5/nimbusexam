using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class OPClaseService(IRepository<OPClase> repository, IRepository<CFAgencia> agenRepository, IMapper mapper) : IOPClaseService
{
    private readonly IRepository<OPClase> _repo = repository;
    private readonly IRepository<CFAgencia> _agenRepo = agenRepository;
    private readonly IMapper _map = mapper;

    public async Task<OPClaseDTO> AddAsync(OPClaseDTO dto)
    {
        try
        {
            OPClase mod = _map.Map<OPClase>(dto);
            mod.ClaseId = Guid.NewGuid();
            await _repo.InsertAsync(mod);
            return dto with { ClaseId = mod.ClaseId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<OPClaseDTO> AttachAsync(Guid id, OPClaseDTO dto)
    {
        try
        {
            OPClase? mod = await _repo.GetAsync(id);
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
            OPClase? mod = await _repo.GetAsync(id);
            if (mod is null) return false;
            mod.Activo = false;
            await _repo.UpdateAsync(mod);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<IEnumerable<Item>> ItemsAsync(string srch)
    {
        throw new NotImplementedException();
    }

    public async Task<OPClaseDTO> PickAsync(Guid id)
    {
        try
        {
            OPClase? mod = await _repo.GetAsync(c => c.ClaseId == id);
            if (mod is null) throw new Exception("Record not found");
            OPClaseDTO dto = _map.Map<OPClaseDTO>(mod);
            dto.Agencia = _map.Map<Item>(await _agenRepo.GetAsync(mod.AgenciaId));
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
