using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class VEUnidadService(
    IRepository<VEUnidad> repository, IMapper mapper,
    IRepository<Brand> repositoryBrand
) : IVEUnidadService
{
    private readonly IRepository<VEUnidad> _repo = repository;
    private readonly IRepository<Brand> _repoB = repositoryBrand;
    private readonly IMapper _map = mapper;

    public async Task<VEUnidadDTO> AddAsync(VEUnidadDTO dto)
    {
        try
        {
            VEUnidad mdl = _map.Map<VEUnidad>(dto);
            mdl.UnidadId = Guid.NewGuid();
            mdl.Registrado = DateTime.Now;
            await _repo.InsertAsync(mdl);
            return dto with { UnidadId = mdl.UnidadId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEUnidadDTO> AttachAsync(Guid id, VEUnidadDTO dto)
    {
        try
        {
            VEUnidad? mdl = await _repo.GetAsync(id);
            if (mdl is null) throw new Exception("Record not found");
            mdl.Adapt(dto);
            await _repo.UpdateAsync(mdl);
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
            IEnumerable<VEUnidad> ls = await _repo.SearchAsync(v => v.Placa.Contains(srch) || v.Modelo.Contains(srch) || v.Anio.Contains(srch) || v.Color.Contains(srch));
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEUnidadDTO> PickAsync(Guid id)
    {
        try
        {
            VEUnidad? mdl = await _repo.GetAsync(id);
            if (mdl is null) throw new Exception("Record not found");
            VEUnidadDTO dto = mdl.Adapt<VEUnidadDTO>();
            Brand? br = await _repoB.GetAsync(mdl.MarcaId);
            dto.Marca = _map.Map<Item>(br!);
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
