using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class OPClaseService(IUnitOfWork unitOfWork) : IOPClaseService
{
    private readonly IUnitOfWork _unit = unitOfWork;
    
    public async Task<int> AddsAsync(Guid? id, IEnumerable<OPClaseDTO> dtos, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPClaseDTO> li = dtos.Where(c => c.Id == null);
            IEnumerable<OPClaseDTO> lu = dtos.Where(c => c.Id != null);
            if (lu.Any())
            {
                Guid[] ids = [.. lu.Select(c => c.Id!.Value)];
                int xi = await _unit.Clases.HasAsync(ids, ct);
                ArgumentOutOfRangeException.ThrowIfNotEqual(ids.Length, xi);
                IEnumerable<OPClase> ls = await _unit.Clases
                    .SearchAsync(c => ids.Contains(c.Id), ct: ct);
                foreach (OPClase c in ls)
                {
                    OPClaseDTO d = lu.First(d => d.Id == c.Id);
                    _unit.Clases.UpdateAsync(c.ToExists(d));
                }
            }

            if (li.Any())
            {
                foreach (OPClaseDTO d in li)
                    _unit.Clases.InsertAsync(d.ToModel(id!.Value));
            }

            await _unit.CommitAsync(ct);
            return dtos.Count();
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
            int qn = await _unit.Clases.HasAsync(ids, ct);
            ArgumentOutOfRangeException.ThrowIfNotEqual(ids.Length, qn);
            IEnumerable<OPClase> ld = await _unit.Clases
                .SearchAsync(c => ids.Contains(c.Id), ct: ct);
            foreach (OPClase c in ld)
            {
                c.Activo = false;
                _unit.Clases.UpdateAsync(c);
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

    public async Task<IEnumerable<Item>> ItemsAsync(Guid id, string srch, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPClase> ls = await _unit.Clases
                .SearchAsync(c => c.AgenciaId == id && c.Activo == true, ct: ct);
            return ls.Select(c => c.ToItem());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
