using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using Mapster;
using MapsterMapper;

namespace exanim.core.Services;

public class BrandService(IRepository<Brand> repository, IMapper mapper) : IBrandService
{
    private readonly IRepository<Brand> _repo = repository;
    private readonly IMapper _map = mapper;

    public async Task<BrandDTO> AddAsync(BrandDTO dto)
    {
        try
        {
            Brand mdl = dto.Adapt<Brand>();
            mdl.BrandId = Guid.NewGuid();
            await _repo.InsertAsync(mdl);
            return dto with { BrandId = mdl.BrandId };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<BrandDTO> AttachAsync(Guid id, BrandDTO dto)
    {
        try
        {
            Brand? mdl = await _repo.GetAsync(id);
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

    public async Task<bool> DownAsync(Guid id)
    {
        try
        {
            Brand? mdl = await _repo.GetAsync(id);
            if (mdl is null) throw new Exception("Record not found");
            if (!mdl.Activo) return false;
            mdl.Activo = false;
            await _repo.UpdateAsync(mdl);
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
            IEnumerable<Brand> ls = await _repo.SearchAsync(b => b.Name.Contains(srch));
            return _map.Map<IEnumerable<Item>>(ls);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<BrandDTO> PickAsync(Guid id)
    {
        try
        {
            Brand? mdl = await _repo.GetAsync(id);
            if (mdl is null) throw new Exception("Record not found");
            return mdl.Adapt<BrandDTO>();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
