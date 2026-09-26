using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class OPBrandService(IUnitOfWork unitOfWork) : IOPBrandService
{
    private readonly IUnitOfWork _unit = unitOfWork;
    public async Task<IEnumerable<Item>> ItemsAsync(AuthMe me, string srch, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPBrand> ls = await _unit.Brands.SearchAsync(b => b.Activo == true);
            return ls.Select(b => b.ToItem());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> AddsAsync(AuthMe me, IEnumerable<BrandDTO> dtos, CancellationToken ct = default)
    {
        try
        {
            int t = dtos.Count();
            ArgumentOutOfRangeException.ThrowIfZero(t);
            IEnumerable<BrandDTO> li = dtos.Where(b => b.Id == null);
            IEnumerable<BrandDTO> lu = dtos.Where(b => b.Id != null);
            if (lu.Any())
            {
                Guid[] r = lu.Select(b => b.Id!.Value).ToArray();
                int c = await _unit.Brands.HasAsync(b => r.Contains(b.Id), ct);
                ArgumentOutOfRangeException.ThrowIfNotEqual(r.Length, c);
                foreach (BrandDTO b in lu)
                    _unit.Brands.UpdateAsync(b.ToPatch());
            }

            if (li.Any())
            {
                _unit.Brands.BulkAsync(li.Select(b => b.ToModel()));
            }

            await _unit.CommitAsync(ct);
            return t;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DownsAsync(Guid[] ids, CancellationToken ct = default)
    {
        try
        {
            int t = ids.Length;
            ArgumentOutOfRangeException.ThrowIfZero(t);
            int c = await _unit.Brands.HasAsync(b => ids.Contains(b.Id), ct);
            ArgumentOutOfRangeException.ThrowIfNotEqual(t, c);
            IEnumerable<OPBrand> lb = await _unit.Brands.SearchAsync(b => ids.Contains(b.Id), ct: ct);
            foreach (OPBrand b in lb)
            {
                b.Activo = false;
                _unit.Brands.UpdateAsync(b);
            }
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
